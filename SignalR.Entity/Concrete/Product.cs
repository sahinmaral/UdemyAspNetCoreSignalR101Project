using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class Product:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }
    
    public ICollection<OrderDetail> OrderDetails { get; set; }
}