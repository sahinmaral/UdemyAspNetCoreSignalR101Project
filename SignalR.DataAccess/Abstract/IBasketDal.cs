using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Abstract;

public interface IBasketDal:IGenericDal<Basket>
{
    List<Basket> GetAllByRestaurantTableId(int id);
}