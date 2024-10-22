using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class Testimonial:BaseEntity
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
}