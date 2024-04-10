using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.ViewComponents.LayoutComponents;

public class LayoutScriptPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}