using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class BasketItem : BaseEntity
{
    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int BasketId { get; set; }
}