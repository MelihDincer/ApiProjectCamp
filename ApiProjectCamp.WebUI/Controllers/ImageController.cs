using ApiProjectCamp.WebUI.Dtos.ImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjectCamp.WebUI.Controllers
{
    public class ImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ImageList()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Images");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultImageDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ImageListWithEdit()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:44338/api/Images");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultImageDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageDto createImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Images", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ImageListWithEdit");
            }

            return View();
        }

        public async Task<IActionResult> DeleteImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44338/api/Images?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ImageListWithEdit");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateImage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44338/api/Images/GetImage?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetByIdImageDto>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage(UpdateImageDto updateImageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44338/api/Images", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ImageListWithEdit");
            }
            return View();
        }
    }
}
