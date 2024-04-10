using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class AdvertisementManager:IAdvertisementService
{
    private readonly IAdvertisementDal _repositoryService;

    public AdvertisementManager(IAdvertisementDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Advertisement entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Advertisement entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(Advertisement entity)
    {
        _repositoryService.Delete(entity);
    }

    public Advertisement? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Advertisement> GetAll(Expression<Func<Advertisement, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public int Count(Expression<Func<Advertisement, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }
}
