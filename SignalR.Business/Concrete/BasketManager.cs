using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class BasketManager:IBasketService
{
    private readonly IBasketDal _repositoryService;

    public BasketManager(IBasketDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Basket entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Basket entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(Basket entity)
    {
        _repositoryService.Delete(entity);
    }

    public Basket? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Basket> GetAll(Expression<Func<Basket, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public int Count(Expression<Func<Basket, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public List<Basket> GetAllByRestaurantTableId(int id)
    {
        return _repositoryService.GetAllByRestaurantTableId(id);
    }
}
