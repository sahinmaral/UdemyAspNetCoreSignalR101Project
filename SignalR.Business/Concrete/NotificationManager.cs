using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class NotificationManager:INotificationService
{
    private readonly INotificationDal _repositoryService;

    public NotificationManager(INotificationDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Notification entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Notification entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(Notification entity)
    {
        _repositoryService.Delete(entity);
    }

    public Notification? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Notification> GetAll(Expression<Func<Notification, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public int Count(Expression<Func<Notification, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public void UpdateStatus(int id)
    {
        var notification = _repositoryService.GetById(id);
        if (notification is null)
            throw new ArgumentNullException("Bildirim bulunamadı");
        notification.Status = !notification.Status;
        _repositoryService.Update(notification);
    }
}
