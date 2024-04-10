using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class DiscountOfDay:BaseEntity
{
    public string Title { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}