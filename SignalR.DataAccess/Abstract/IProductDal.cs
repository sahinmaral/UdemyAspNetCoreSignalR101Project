using System.Linq.Expressions;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Abstract;

public interface IProductDal:IGenericDal<Product>
{
    List<Product> GetAllWithCategories(Expression<Func<Product, bool>>? predicate = null);
}