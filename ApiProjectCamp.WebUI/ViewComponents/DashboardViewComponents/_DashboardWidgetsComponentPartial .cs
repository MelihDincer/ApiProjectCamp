using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ApiProjectCamp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardWidgetsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int r1, r2, r3, r4;
            Random rnd = new Random();
            r1 = rnd.Next(1, 35);
            r2 = rnd.Next(1, 35);
            r3 = rnd.Next(1, 35);
            r4 = rnd.Next(1, 35);

            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7208/api/Reservations/GetTotalReservastionCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.totalReservationCount = jsonData;
            ViewBag.r1 = r1;

            HttpClient client2 = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage2 = await client.GetAsync("https://localhost:7208/api/Reservations/GetTotalCustomerCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.totalCustomerCount = jsonData2;
            ViewBag.r2 = r2;

            HttpClient client3 = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage3 = await client.GetAsync("https://localhost:7208/api/Reservations/GetPendingReservations");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.pendingReservations = jsonData3;
            ViewBag.r3 = r3;

            HttpClient client4 = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage4 = await client.GetAsync("https://localhost:7208/api/Reservations/GetApprovedReservations");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.approvedReservations = jsonData4;
            ViewBag.r4 = r4;

            return View();
        }
    }
}
