using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfHighlightDal:GenericRepository<Highlight>,IHighlightDal
{
    public EfHighlightDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}