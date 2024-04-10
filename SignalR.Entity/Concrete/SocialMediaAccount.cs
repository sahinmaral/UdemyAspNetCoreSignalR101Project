using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class SocialMediaAccount : BaseEntity
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}