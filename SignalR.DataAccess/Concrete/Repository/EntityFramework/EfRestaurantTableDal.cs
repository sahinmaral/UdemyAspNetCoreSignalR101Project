using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfRestaurantTableDal:GenericRepository<RestaurantTable>,IRestaurantTableDal
{
    public EfRestaurantTableDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}