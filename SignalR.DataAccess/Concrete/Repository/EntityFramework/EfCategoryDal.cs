using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfCategoryDal:GenericRepository<Category>,ICategoryDal
{
    public EfCategoryDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}