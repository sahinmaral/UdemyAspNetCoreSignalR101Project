using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Context;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Repository.EntityFramework;

public class EfBasketDal:GenericRepository<Basket>,IBasketDal
{
    private readonly SignalRDbContext _dbContext;

    public EfBasketDal(SignalRDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Basket> GetAllByRestaurantTableId(int id)
    {
        return _dbContext.Baskets
            .Include(basket => basket.RestaurantTable)
            .Include(basket => basket.BasketItems)
            .ThenInclude(basketItem => basketItem.Product)
            .Where(basket => basket.RestaurantTableId == id)
            .ToList();
    }
}