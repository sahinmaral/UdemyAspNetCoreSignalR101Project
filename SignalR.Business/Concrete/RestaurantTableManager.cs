using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class RestaurantTableManager:IRestaurantTableService
{
    private readonly IRestaurantTableDal _repositoryService;

    public RestaurantTableManager(IRestaurantTableDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(RestaurantTable entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(RestaurantTable entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(RestaurantTable entity)
    {
        _repositoryService.Delete(entity);
    }

    public RestaurantTable? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<RestaurantTable> GetAll(Expression<Func<RestaurantTable, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public int Count(Expression<Func<RestaurantTable, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }
}
