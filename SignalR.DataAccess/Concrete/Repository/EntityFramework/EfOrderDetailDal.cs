using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfOrderDetailDal:GenericRepository<OrderDetail>,IOrderDetailDal
{
    public EfOrderDetailDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}