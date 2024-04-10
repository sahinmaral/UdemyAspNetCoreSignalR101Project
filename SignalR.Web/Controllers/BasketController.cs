using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Basket;

namespace SignalR.Web.Controllers;

public class BasketController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public BasketController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<IActionResult> Index()
    {
        var basket = await GetBasket();
        return View(basket);
    }
    
    private async Task<ResultBasketViewModel> GetBasket()
    {
        using var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Basket/GetAllByRestaurantTableId/5");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBasketViewModel>>(jsonData);
            return values.First();
        }
            
        throw new HttpRequestException($"Sepet alınırken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
}