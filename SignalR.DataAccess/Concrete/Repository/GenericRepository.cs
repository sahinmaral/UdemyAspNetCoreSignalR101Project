using System.Linq.Expressions;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Abstract;

namespace SignalR.DataAccess.Concrete.Repository;

public class GenericRepository<T>:IGenericDal<T> where T:BaseEntity,new()
{
    private readonly SignalRDbContext _dbContext;

    public GenericRepository(SignalRDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(T entity)
    {
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
    }

    public T? GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public List<T> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate is null ? 
            _dbContext.Set<T>().ToList() : 
            _dbContext.Set<T>().Where(predicate).ToList();
    }

    public int Count(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate is null ? _dbContext.Set<T>().Count() : _dbContext.Set<T>().Count(predicate);
    }
}