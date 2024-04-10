using System.Linq.Expressions;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Abstract;

public interface IProductService:IGenericService<Product>
{
    List<Product> GetAllWithCategories(Expression<Func<Product, bool>>? predicate = null);
    int CountByCategoryName(string categoryName);
    decimal GetAveragePriceOfAllProducts();
    string? GetMinimumPriceProductName();
    string? GetMaximumPriceProductName();
    decimal GetAveragePriceWithHamburgerCategory();
}