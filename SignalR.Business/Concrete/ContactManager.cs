using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class ContactManager:IContactService
{
    private readonly IContactDal _repositoryService;

    public ContactManager(IContactDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Contact entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Contact entity)
    {
        _repositoryService.Update(entity);
    }
    
    public int Count(Expression<Func<Contact, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public void Delete(Contact entity)
    {
        _repositoryService.Delete(entity);
    }

    public Contact? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Contact> GetAll(Expression<Func<Contact, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }
}