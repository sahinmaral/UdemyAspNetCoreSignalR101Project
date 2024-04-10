using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Contact;

namespace SignalR.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ContactController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Contact",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Contact/Index");
            }
            return View();
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.DeleteAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Contact/Index");
            }
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetContactViewModel>(jsonData);
                return View(value);
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Contact",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Contact/Index");
            }
            return View();
        }
    }
}