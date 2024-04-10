using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Product;

namespace SignalR.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Product/CategoryDetail");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        
        public async Task<IActionResult> Create()
        {
            var categories = await GetCategories();
            ViewBag.Categories = categories.Select(model => new SelectListItem
            {
                Value = model.Id.ToString(),
                Text = model.Name
            }).ToList();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Product",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Reservation/Index");
            }
            
            var categories = await GetCategories();
            ViewBag.Categories = categories.Select(model => new SelectListItem
            {
                Value = model.Id.ToString(),
                Text = model.Name
            }).ToList();
            return View();
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            
            var responseMessage = await client.DeleteAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }

        private async Task<List<ResultProductWithCategoryViewModel>?> GetCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryViewModel>>(jsonData);
                return values;
            }

            return null;
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var categories = await GetCategories();
            ViewBag.Categories = categories.Select(model => new SelectListItem
            {
                Value = model.Id.ToString(),
                Text = model.Name
            }).ToList();
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Product/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetProductViewModel>(jsonData);
                return View(value);
            }
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Product",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/Index");
            }
            
            var categories = await GetCategories();
            ViewBag.Categories = categories.Select(model => new SelectListItem
            {
                Value = model.Id.ToString(),
                Text = model.Name
            }).ToList();
            return View();
        }
    }
}