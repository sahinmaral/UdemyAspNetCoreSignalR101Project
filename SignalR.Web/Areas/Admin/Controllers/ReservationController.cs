using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Reservation;

namespace SignalR.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ReservationController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Reservation",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Reservation/Index");
            }
            return View();
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.DeleteAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Reservation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Reservation/Index");
            }
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Reservation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetReservationViewModel>(jsonData);
                return View(value);
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateReservationViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Reservation",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Reservation/Index");
            }
            return View();
        }
    }
}