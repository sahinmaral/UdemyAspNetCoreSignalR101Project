using System.Linq.Expressions;
using SignalR.Entity.Abstract;

namespace SignalR.Business.Abstract;

public interface IGenericService<T> where T:BaseEntity,new()
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    T? GetById(int id);
    List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
    int Count(Expression<Func<T, bool>>? predicate = null);
}