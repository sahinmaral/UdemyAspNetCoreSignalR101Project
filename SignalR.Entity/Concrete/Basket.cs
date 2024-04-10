using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class Basket : BaseEntity
{
    public ICollection<BasketItem> BasketItems { get; set; }
    public RestaurantTable RestaurantTable { get; set; }
    public int RestaurantTableId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}