using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfSocialMediaAccountDal:GenericRepository<SocialMediaAccount>,ISocialMediaAccountDal
{
    public EfSocialMediaAccountDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}