using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class HighlightManager:IHighlightService
{
    private readonly IHighlightDal _repositoryService;

    public HighlightManager(IHighlightDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Highlight entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Highlight entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(Highlight entity)
    {
        _repositoryService.Delete(entity);
    }

    public int Count(Expression<Func<Highlight, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }
    public Highlight? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Highlight> GetAll(Expression<Func<Highlight, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }
}