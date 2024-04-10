using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class Contact:BaseEntity
{
    public string LocationUrl { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string OpenDays { get; set; }
    public string OpenHours { get; set; }
}