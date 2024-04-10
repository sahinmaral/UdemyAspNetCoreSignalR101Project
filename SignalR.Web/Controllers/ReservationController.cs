using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Web.ViewModels.Reservation;

namespace SignalR.Web.Controllers;

public class ReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public ReservationController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationViewModel viewModel)
    {
        await CreateReservation(viewModel);
        
        return RedirectToAction("Index","Home");
    }
    
    private async Task CreateReservation(CreateReservationViewModel viewModel) 
    {
        var client = _httpClientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(viewModel);
        var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync($"{_configuration.GetSection("APIBaseUrl").Value}/Reservation",stringContent);
        if (responseMessage.IsSuccessStatusCode)
        {
            return;
        }
        
        throw new HttpRequestException($"Rezervasyon kaydedilirken hata oluştu. Durum kodu: {responseMessage.StatusCode}");
    }
}