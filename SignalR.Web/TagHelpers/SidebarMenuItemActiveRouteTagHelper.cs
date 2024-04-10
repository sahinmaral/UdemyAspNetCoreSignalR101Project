using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SignalR.Web.Areas.Admin.TagHelpers;

[HtmlTargetElement("li", Attributes = "active-route")]
public class SidebarMenuItemActiveRouteTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    [HtmlAttributeName("active-route")]
    public string ActiveRoute { get; set; }

    public SidebarMenuItemActiveRouteTagHelper(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (ShouldBeActive())
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (classAttr == null)
            {
                output.Attributes.Add("class", "active");
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active") == -1)
            {
                output.Attributes.SetAttribute("class", classAttr.Value + " active");
            }
        }
    }

    private bool ShouldBeActive()
    {
        if (string.IsNullOrEmpty(ActiveRoute))
            return false;

        var currentPage = _httpContextAccessor.HttpContext.Request.Path;

        return currentPage.StartsWithSegments(ActiveRoute);
    }
}
