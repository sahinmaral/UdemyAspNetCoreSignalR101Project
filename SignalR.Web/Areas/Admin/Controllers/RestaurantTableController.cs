using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.RestaurantTable;

namespace SignalR.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantTableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public RestaurantTableController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/RestaurantTable");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRestaurantTableViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        
        // public async Task<IActionResult> Create()
        // {
        //     var categories = await GetCategories();
        //     ViewBag.Categories = categories.Select(model => new SelectListItem
        //     {
        //         Value = model.Id.ToString(),
        //         Text = model.Name
        //     }).ToList();
        //     
        //     return View();
        // }
        //
        // [HttpPost]
        // public async Task<IActionResult> Create(CreateRestaurantTableViewModel viewModel)
        // {
        //     var client = _httpClientFactory.CreateClient();
        //     var jsonData = JsonConvert.SerializeObject(viewModel);
        //     var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //     var responseMessage = await client.PostAsync($"{_configuration.GetSection("APIBaseUrl").Value}/RestaurantTable",stringContent);
        //     if (responseMessage.IsSuccessStatusCode)
        //     {
        //         return Redirect("/Admin/Reservation/Index");
        //     }
        //     
        //     var categories = await GetCategories();
        //     ViewBag.Categories = categories.Select(model => new SelectListItem
        //     {
        //         Value = model.Id.ToString(),
        //         Text = model.Name
        //     }).ToList();
        //     return View();
        // }

    }
}