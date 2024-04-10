using System.Linq.Expressions;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Abstract;
using SignalR.Entity.Concrete;

namespace SignalR.Business.Concrete;

public class ProductManager:IProductService
{
    private readonly IProductDal _repositoryService;

    public ProductManager(IProductDal repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void Add(Product entity)
    {
        _repositoryService.Add(entity);
    }

    public void Update(Product entity)
    {
        _repositoryService.Update(entity);
    }

    public void Delete(Product entity)
    {
        _repositoryService.Delete(entity);
    }
    
    public int Count(Expression<Func<Product, bool>>? predicate = null)
    {
        return _repositoryService.Count(predicate);
    }

    public Product? GetById(int id)
    {
        return _repositoryService.GetById(id);
    }

    public List<Product> GetAll(Expression<Func<Product, bool>>? predicate = null)
    {
        return _repositoryService.GetAll(predicate);
    }

    public List<Product> GetAllWithCategories(Expression<Func<Product, bool>>? predicate = null)
    {
        return _repositoryService.GetAllWithCategories(predicate);
    }

    public int CountByCategoryName(string categoryName)
    {
        return _repositoryService.GetAllWithCategories(product => product.Category.Name.Contains(categoryName)).Count;
    }

    public decimal GetAveragePriceOfAllProducts()
    {
        return _repositoryService
            .GetAll()
            .Average(product => product.Price);
    }

    public string? GetMinimumPriceProductName()
    {
        return _repositoryService
            .GetAll().MinBy(product => product.Price)?.Name;
    }

    public string? GetMaximumPriceProductName()
    {
        return _repositoryService
            .GetAll().MaxBy(product => product.Price)?.Name;
    }

    public decimal GetAveragePriceWithHamburgerCategory()
    {
        return _repositoryService.GetAllWithCategories(product => product.Category.Name == "Hamburger")
            .Average(product => product.Price);
    }
}