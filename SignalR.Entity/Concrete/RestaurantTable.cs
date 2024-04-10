using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class RestaurantTable : BaseEntity
{
    public string Name { get; set; }
    public bool Status { get; set; }
}