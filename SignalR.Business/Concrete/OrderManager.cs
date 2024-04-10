using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Dto.Order;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class OrderManager:IOrderService
{
    private readonly IOrderDal _repositoryService;

    public OrderManager(IOrderDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Order entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Order entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(Order entity)
    {
        _repositoryService.Delete(entity);
    }

    public Order? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Order> GetAll(Expression<Func<Order, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public int Count(Expression<Func<Order, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public OrderCountDto GetOrderCountDetailed()
    {
        var allOrders = _repositoryService.Count();
        var activeOrders = _repositoryService.Count(order => order.Status == OrderStatus.CustomerAtTheTable);
        var closedOrders = _repositoryService.Count(order => order.Status == OrderStatus.AccountClosed);

        OrderCountDto orderCountDto = new OrderCountDto
        {
            All = allOrders,
            Active = activeOrders,
            Closed = closedOrders
        };

        return orderCountDto;
    }

    public decimal GetLastOrderTotalPrice()
    {
        var lastOrder = _repositoryService.GetAll().MaxBy(order => order.Date);
        if (lastOrder is null)
            throw new NullReferenceException("Herhangi bir sipariş yok");
        return lastOrder.TotalPrice;
    }

    public decimal GetTodayEarning()
    {
        return _repositoryService.GetAll(order => order.Date.Date == DateTime.Today)
            .Sum(order => order.TotalPrice);
    }
}
