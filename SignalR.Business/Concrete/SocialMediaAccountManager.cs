using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class SocialMediaAccountManager:ISocialMediaAccountService
{
    private readonly ISocialMediaAccountDal _repositoryService;

    public SocialMediaAccountManager(ISocialMediaAccountDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(SocialMediaAccount entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(SocialMediaAccount entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(SocialMediaAccount entity)
    {
        _repositoryService.Delete(entity);
    }
    
    public int Count(Expression<Func<SocialMediaAccount, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public SocialMediaAccount? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<SocialMediaAccount> GetAll(Expression<Func<SocialMediaAccount, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }
}