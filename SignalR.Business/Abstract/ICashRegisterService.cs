using SignalR.Entity.Concrete;

namespace SignalR.Business.Abstract;

public interface ICashRegisterService:IGenericService<CashRegister>
{
    decimal GetTotalCashRegisterAmount();
}