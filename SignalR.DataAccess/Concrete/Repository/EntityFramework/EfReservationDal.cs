using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfReservationDal:GenericRepository<Reservation>,IReservationDal
{
    public EfReservationDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}