using SignalR.Web.ViewModels.BasketItem;
using SignalR.Web.ViewModels.RestaurantTable;

namespace SignalR.Web.ViewModels.Basket;

public class CreateBasketViewModel
{
    public ICollection<CreateBasketItemViewModel> BasketItems { get; set; }
    public ResultRestaurantTableViewModel RestaurantTable { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}