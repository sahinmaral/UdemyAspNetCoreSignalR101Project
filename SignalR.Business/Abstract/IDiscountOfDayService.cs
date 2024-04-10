using SignalR.Entity.Concrete;

namespace SignalR.Business.Abstract;

public interface IDiscountOfDayService:IGenericService<DiscountOfDay>
{
    void UpdateStatus(int id);
}