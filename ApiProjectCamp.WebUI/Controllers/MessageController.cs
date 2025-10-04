using ApiProjectCamp.WebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static ApiProjectCamp.WebUI.Controllers.AIController;

namespace ApiProjectCamp.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Messages");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Messages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return RedirectToAction("CreateMessage");
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:44338/api/Messages?id=" + id);
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Messages/GetMessage?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdMessageDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44338/api/Messages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AnswerMessageWithOpenAI(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Messages/GetMessage?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdMessageDto>(jsonData);

                string prompt = value.MessageDetails;
                //AI Entegrasyonu
                var apiKey = "";
                using var client2 = new HttpClient();
                client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var requestData = new
                {
                    model = "gpt-4o-mini",
                    messages = new[]
                    {
                    new
                    {
                        role="system", content="Sen bir restoran için kullanıcıların göndermiş oldukları mesajları detaylı ve olabildiğince olumlu müşteri memnuniyeti gözeten cevaplar veren bir yapay zeka aracısın. Amacımız kullanıcı tarafından gönderilen mesajlara en olumlu ve en mantıklı cevapları sunabilmek."
                    },
                    new
                    {
                        role="user", content=prompt
                    }
                },
                    temperature = 0.5 //Oluşturulacak içeriğin resmi/kurumsal ve daha basic olma oranı.
                };
                var response = await client2.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                    var content = result.choices[0].message.content;
                    ViewBag.answerAI = content;
                }
                else
                {
                    ViewBag.answerAI = "Bir hata oluştu. Hata mesajı: " + response.StatusCode;
                }

                return View(value);
            }
            return View();
        }
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            var client2 = new HttpClient();
            var apiKey = "";
            client2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            try
            {
                var translateRequestBody = new
                {
                    inputs = createMessageDto.MessageDetails
                };
                var translateJson = System.Text.Json.JsonSerializer.Serialize(translateRequestBody);
                var translateContent = new StringContent(translateJson, Encoding.UTF8, "application/json");

                var translateResponse = await client2.PostAsync("https://api-inference.hugging-face.co/models/Helsinki-NLP/opus-mt-tr-en", translateContent);
                var translateResponseString = await translateResponse.Content.ReadAsStringAsync();

                string englishText = createMessageDto.MessageDetails;
                if (translateResponseString.TrimStart().StartsWith("["))
                {
                    var translateDoc = JsonDocument.Parse(translateResponseString);
                    englishText = translateDoc.RootElement[0].GetProperty("translation_textr").GetString();
                    ViewBag.v = englishText;
                }

                var toxicRequestBody = new
                {
                    inputs = englishText
                };
                var toxicJson = System.Text.Json.JsonSerializer.Serialize(toxicRequestBody);
                var toxicContext = new StringContent(toxicJson, Encoding.UTF8, "application/json");
                var toxicResponse = await client2.PostAsync("https://api-inference.hugging-face.co/models/unitary/toxic-bert", toxicContext);//label=>Toxiclik Etiketi, score=>Toxiclik oranı
                var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();
                if (toxicResponseString.TrimStart().StartsWith("["))
                {
                    var toxicDoc = JsonDocument.Parse(toxicResponseString);
                    foreach (var item in toxicDoc.RootElement[0].EnumerateArray())
                    {
                        string label = item.GetProperty("label").GetString();
                        double score = item.GetProperty("score").GetDouble();
                        if (score > 0.5)
                        {
                            createMessageDto.Status = "Toxic Mesaj";
                            break;
                        }
                    }
                }
                if (string.IsNullOrEmpty(createMessageDto.Status))
                {
                    createMessageDto.Status = "Mesaj Alındı";
                }
            }
            catch (Exception ex)
            {
                createMessageDto.Status = "Onay Bekliyor";
            }

            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Messages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Mesajınız başarıyla gönderildi. Teşekkür ederiz 😊";
            }
            else
            {
                TempData["Error"] = "Bir hata oluştu ❌";
            }
            return RedirectToAction("Index", "Default");
        }
    }
}
