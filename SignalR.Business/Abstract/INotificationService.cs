using SignalR.Entity.Concrete;

namespace SignalR.Business.Abstract;

public interface INotificationService:IGenericService<Notification>
{
    void UpdateStatus(int id);
}