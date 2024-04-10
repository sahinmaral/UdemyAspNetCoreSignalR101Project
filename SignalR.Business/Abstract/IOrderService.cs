using SignalR.Dto.Order;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Abstract;

public interface IOrderService:IGenericService<Order>
{
    OrderCountDto GetOrderCountDetailed();
    decimal GetLastOrderTotalPrice();
    decimal GetTodayEarning();
}