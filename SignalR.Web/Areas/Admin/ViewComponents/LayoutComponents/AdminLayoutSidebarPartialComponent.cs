using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.Areas.Admin.ViewComponents.LayoutComponents;

public class AdminLayoutSidebarPartialComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}