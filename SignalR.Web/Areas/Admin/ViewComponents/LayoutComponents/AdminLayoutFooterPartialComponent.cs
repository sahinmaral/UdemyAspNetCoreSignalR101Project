using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.Areas.Admin.ViewComponents.LayoutComponents;

public class AdminLayoutFooterPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}