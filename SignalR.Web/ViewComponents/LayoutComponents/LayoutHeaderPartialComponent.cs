using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class LayoutHeaderPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}