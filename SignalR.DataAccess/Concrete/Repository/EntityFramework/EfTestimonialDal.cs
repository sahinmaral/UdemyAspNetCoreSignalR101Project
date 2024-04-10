using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfTestimonialDal:GenericRepository<Testimonial>,ITestimonialDal
{
    public EfTestimonialDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}