using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class Order:BaseEntity
{
    public int RestaurantTableId { get; set; }
    public RestaurantTable RestaurantTable { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime Date { get; set; }
    public decimal TotalPrice { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; }
}