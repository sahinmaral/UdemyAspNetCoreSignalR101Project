using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class CreateReservationPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}