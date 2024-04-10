using SignalR.Entity.Abstract;

namespace SignalR.Entity.Concrete;

public class CashRegister : BaseEntity
{
    public int Id { get; set; }
    public decimal TotalAmount { get; set; }
}