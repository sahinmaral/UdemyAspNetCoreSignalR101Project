using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Contact;
using SignalR.Web.ViewModels.SocialMediaAccount;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class LayoutFooterPartialComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public LayoutFooterPartialComponent(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.SocialMediaAccounts = await GetSocialMediaAccounts();
        ViewBag.Contact = await GetContact();
        
        return View();
    }
    
    private async Task<List<ResultSocialMediaAccountViewModel>> GetSocialMediaAccounts()
    {
        using var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/SocialMediaAccount");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaAccountViewModel>>(jsonData);
            return values;
        }
            
        throw new HttpRequestException($"Sosyal medya hesapları alınırken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
    
    private async Task<ResultContactViewModel> GetContact()
    {
        using var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Contact");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactViewModel>>(jsonData);
            return values.First();
        }
            
        throw new HttpRequestException($"Hakkında alınırken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
}