using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class ReservationManager:IReservationService
{
    private readonly IReservationDal _repositoryService;

    public ReservationManager(IReservationDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Reservation entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Reservation entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(Reservation entity)
    {
        _repositoryService.Delete(entity);
    }
    
    public int Count(Expression<Func<Reservation, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public Reservation? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Reservation> GetAll(Expression<Func<Reservation, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }
}