using ApiProjectCamp.WebUI.Dtos.WhyChooseYummyDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectCamp.WebUI.Controllers
{
    public class WhyChooseYummyController : Controller
    {    
        private readonly IHttpClientFactory _httpClientFactory;

        public WhyChooseYummyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> WhyChooseYummyList()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhyChooseYummyDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateWhyChooseYummy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhyChooseYummy(CreateWhyChooseYummyDto createWhyChooseYummyDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWhyChooseYummyDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Services", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyChooseYummyList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteWhyChooseYummy(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:44338/api/Services?id=" + id);
            return RedirectToAction("WhyChooseYummyList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWhyChooseYummy(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Services/GetService?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdWhyChooseYummyDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWhyChooseYummy(UpdateWhyChooseYummyDto updateWhyChooseYummyDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateWhyChooseYummyDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44338/api/Services", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("WhyChooseYummyList");
            }
            return View();
        }
    }
}
