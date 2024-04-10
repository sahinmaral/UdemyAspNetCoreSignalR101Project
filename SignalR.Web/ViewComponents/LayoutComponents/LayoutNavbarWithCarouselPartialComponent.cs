using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Advertisement;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class LayoutNavbarWithCarouselPartialComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public LayoutNavbarWithCarouselPartialComponent(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.Advertisement = await GetAdvertisementAsync();

        return View();
    }
    
    private async Task<ResultAdvertisementViewModel?> GetAdvertisementAsync()
    {
        using (var client = _httpClientFactory.CreateClient())
        {
            var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Advertisement");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAdvertisementViewModel>(jsonData);
                return values;
            }
            
            return null;
        }
    }
}
