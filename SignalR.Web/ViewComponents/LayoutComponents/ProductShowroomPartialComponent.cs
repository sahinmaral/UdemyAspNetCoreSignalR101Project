using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Category;
using SignalR.Web.ViewModels.Product;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class ProductShowroomPartialComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public ProductShowroomPartialComponent(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.Categories = await GetCategories();
        ViewBag.Products = await GetProductsDetailed();
        
        return View();
    }
    
    private async Task<List<ResultCategoryViewModel>> GetCategories()
    {
        using var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Category");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryViewModel>>(jsonData);
            return values;
        }
            
        throw new HttpRequestException($"Kategorileri alırken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
    
    private async Task<List<ResultProductWithCategoryViewModel>> GetProductsDetailed()
    {
        using var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Product/CategoryDetail");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryViewModel>>(jsonData);
            return values;
        }
            
        throw new HttpRequestException($"Ürünleri alırken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
}