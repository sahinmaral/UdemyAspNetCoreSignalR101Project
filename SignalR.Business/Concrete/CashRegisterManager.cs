using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class CashRegisterManager:ICashRegisterService
{
    private readonly ICashRegisterDal _repositoryService;

    public CashRegisterManager(ICashRegisterDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(CashRegister entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(CashRegister entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(CashRegister entity)
    {
        _repositoryService.Delete(entity);
    }

    public CashRegister? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<CashRegister> GetAll(Expression<Func<CashRegister, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public int Count(Expression<Func<CashRegister, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public decimal GetTotalCashRegisterAmount()
    {
        return _repositoryService.GetAll().Select(register => register.TotalAmount).First();
    }
}
