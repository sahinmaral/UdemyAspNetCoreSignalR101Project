using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}