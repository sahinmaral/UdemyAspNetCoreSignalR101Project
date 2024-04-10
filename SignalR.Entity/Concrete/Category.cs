using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class Category: BaseEntity
{
    public string Name { get; set; }
    public bool Status { get; set; }

    public ICollection<Product> Products { get; set; }
}