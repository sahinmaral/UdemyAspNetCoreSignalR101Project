using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfProductDal:GenericRepository<Product>,IProductDal
{
    private readonly SignalRDbContext _dbContext;

    public EfProductDal(SignalRDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Product> GetAllWithCategories(Expression<Func<Product, bool>>? predicate = null)
    {
        return predicate is null ? 
            _dbContext.Products
            .Include(product => product.Category)
            .ToList()
        :
        _dbContext.Products
            .Include(product => product.Category)
            .Where(predicate)
            .ToList();
    }
}