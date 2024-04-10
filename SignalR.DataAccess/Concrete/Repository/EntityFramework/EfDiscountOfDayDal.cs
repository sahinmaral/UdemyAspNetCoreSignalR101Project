using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfDiscountOfDayDal:GenericRepository<DiscountOfDay>,IDiscountOfDayDal
{
    public EfDiscountOfDayDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}