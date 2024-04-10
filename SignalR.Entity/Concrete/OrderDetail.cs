using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class OrderDetail : BaseEntity
{

    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
}