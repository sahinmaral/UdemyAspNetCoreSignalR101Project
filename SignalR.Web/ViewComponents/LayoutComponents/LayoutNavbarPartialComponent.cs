using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class LayoutNavbarPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}