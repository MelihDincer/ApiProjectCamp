using ApiProjectCamp.WebUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectCamp.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AboutList()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Abouts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await client.PostAsync("https://localhost:44338/api/Abouts", stringContent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"https://localhost:44338/api/Abouts?id={id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await client.GetAsync($"https://localhost:44338/api/Abouts/GetAbout?id={id}");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await httpResponseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdAboutDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await client.PutAsync("https://localhost:44338/api/Abouts", content);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }
    }
}
