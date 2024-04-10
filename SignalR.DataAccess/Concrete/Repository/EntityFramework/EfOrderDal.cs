using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfOrderDal:GenericRepository<Order>,IOrderDal
{
    public EfOrderDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}