using ApiProjectCamp.WebUI.Dtos.ActivityDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectCamp.WebUI.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ActivityController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ActivityList()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Activities");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultActivityDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateActivity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(CreateActivityDto createActivityDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createActivityDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Activities", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ActivityList");
            }
            return RedirectToAction("CreateActivity");
        }

        public async Task<IActionResult> DeleteActivity(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:44338/api/Activities?id=" + id);
            return RedirectToAction("ActivityList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateActivity(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Activities/GetActivity?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdActivityDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActivity(UpdateActivityDto updateActivityDto)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateActivityDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44338/api/Activities", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ActivityList");
            }
            return View();
        }
    }
}
