using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfCashRegisterDal:GenericRepository<CashRegister>,ICashRegisterDal
{
    public EfCashRegisterDal(SignalRDbContext dbContext) : base(dbContext)
    {
    }
}