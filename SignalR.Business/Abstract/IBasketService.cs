using SignalR.Entity.Concrete;

namespace SignalR.Business.Abstract;

public interface IBasketService:IGenericService<Basket>
{
    List<Basket> GetAllByRestaurantTableId(int id);
}