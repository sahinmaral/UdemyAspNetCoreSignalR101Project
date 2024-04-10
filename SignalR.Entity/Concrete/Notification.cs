using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class Notification : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}