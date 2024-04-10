using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.DiscountOfDay;

namespace SignalR.Web.Controllers;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public HomeController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Discounts = await GetDiscounts();
        return View();
    }
    
    private async Task<List<ResultDiscountOfDayViewModel>> GetDiscounts()
    {
        using var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/DiscountOfDay");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountOfDayViewModel>>(jsonData);
            return values.Where(discount => discount.Status).ToList();
        }
            
        throw new HttpRequestException($"İndirimleri alırken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
}