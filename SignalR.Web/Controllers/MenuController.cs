using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.Controllers;

public class MenuController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}