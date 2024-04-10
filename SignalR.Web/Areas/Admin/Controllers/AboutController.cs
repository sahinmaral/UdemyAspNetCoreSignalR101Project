using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.About;

namespace SignalR.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AboutController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_configuration.GetSection("APIBaseUrl").Value}/About",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/About/Index");
            }
            return View();
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.DeleteAsync($"{_configuration.GetSection("APIBaseUrl").Value}/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/About/Index");
            }
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/About/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetAboutViewModel>(jsonData);
                return View(value);
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_configuration.GetSection("APIBaseUrl").Value}/About",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/About/Index");
            }
            return View();
        }
    }
}