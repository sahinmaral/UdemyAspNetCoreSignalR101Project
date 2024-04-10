using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class OrderDetailManager:IOrderDetailService
{
    private readonly IOrderDetailDal _repositoryService;

    public OrderDetailManager(IOrderDetailDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(OrderDetail entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(OrderDetail entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(OrderDetail entity)
    {
        _repositoryService.Delete(entity);
    }

    public OrderDetail? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public int Count(Expression<Func<OrderDetail, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }
}
