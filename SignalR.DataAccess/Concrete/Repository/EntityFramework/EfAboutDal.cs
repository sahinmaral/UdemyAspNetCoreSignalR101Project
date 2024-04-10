using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfAboutDal:GenericRepository<About>,IAboutDal
{
    public EfAboutDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}