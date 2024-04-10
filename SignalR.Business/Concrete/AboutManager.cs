using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class AboutManager:IAboutService
{
    private readonly IAboutDal _repositoryService;

    public AboutManager(IAboutDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(About entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(About entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(About entity)
    {
        _repositoryService.Delete(entity);
    }

    public About? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<About> GetAll(Expression<Func<About, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public int Count(Expression<Func<About, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }
}
