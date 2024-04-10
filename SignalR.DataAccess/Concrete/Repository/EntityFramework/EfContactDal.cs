using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfContactDal:GenericRepository<Contact>,IContactDal
{
    public EfContactDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}