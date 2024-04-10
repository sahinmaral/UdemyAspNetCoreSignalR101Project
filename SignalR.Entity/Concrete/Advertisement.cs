using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class Advertisement : BaseEntity
{
    public string Title1 { get; set; }
    public string Title2 { get; set; }
    public string Title3 { get; set; }
    
    public string Description1 { get; set; }
    public string Description2 { get; set; }
    public string Description3 { get; set; }
}