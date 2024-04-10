using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.About;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class AboutPartialComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public AboutPartialComponent(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var about = await GetAbout();
        
        return View(about);
    }
    
    private async Task<ResultAboutViewModel> GetAbout()
    {
        using var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/About");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultAboutViewModel>>(jsonData);
            return values.First();
        }
            
        throw new HttpRequestException($"Hakkında alınırken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
}