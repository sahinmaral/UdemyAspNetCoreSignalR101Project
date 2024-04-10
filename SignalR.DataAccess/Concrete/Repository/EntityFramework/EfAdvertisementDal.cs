using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfAdvertisementDal:GenericRepository<Advertisement>,IAdvertisementDal
{
    public EfAdvertisementDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}