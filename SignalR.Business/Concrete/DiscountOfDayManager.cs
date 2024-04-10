using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class DiscountOfDayManager:IDiscountOfDayService
{
    private readonly IDiscountOfDayDal _repositoryService;

    public DiscountOfDayManager(IDiscountOfDayDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(DiscountOfDay entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(DiscountOfDay entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(DiscountOfDay entity)
    {
        _repositoryService.Delete(entity);
    }
    
    public int Count(Expression<Func<DiscountOfDay, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public void UpdateStatus(int id)
    {
        var notification = _repositoryService.GetById(id);
        if (notification is null)
            throw new ArgumentNullException("Günün indirimi bulunamadı");
        notification.Status = !notification.Status;
        _repositoryService.Update(notification);
    }

    public DiscountOfDay? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<DiscountOfDay> GetAll(Expression<Func<DiscountOfDay, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }
}