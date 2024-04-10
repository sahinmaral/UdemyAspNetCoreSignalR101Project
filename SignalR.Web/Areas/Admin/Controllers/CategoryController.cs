using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Category;

namespace SignalR.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CategoryController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Category",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Category/Index");
            }
            return View();
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.DeleteAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Category/Index");
            }
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetCategoryViewModel>(jsonData);
                return View(value);
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Category",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Category/Index");
            }
            return View();
        }
    }
}