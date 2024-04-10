using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.Areas.Admin.ViewComponents.LayoutComponents;

public class AdminLayoutScriptPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}