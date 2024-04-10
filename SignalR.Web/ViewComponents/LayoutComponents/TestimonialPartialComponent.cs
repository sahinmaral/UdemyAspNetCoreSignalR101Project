using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Testimonial;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class TestimonialPartialComponent : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public TestimonialPartialComponent(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var testimonials = await GetTestimonials();
        
        return View(testimonials);
    }
    
    private async Task<List<ResultTestimonialViewModel>> GetTestimonials()
    {
        using var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Testimonial");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialViewModel>>(jsonData);
            return values;
        }
            
        throw new HttpRequestException($"Referansları alırken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
}