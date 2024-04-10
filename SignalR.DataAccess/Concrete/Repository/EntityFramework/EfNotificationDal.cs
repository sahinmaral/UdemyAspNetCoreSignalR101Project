using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfNotificationDal:GenericRepository<Notification>,INotificationDal
{
    public EfNotificationDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}