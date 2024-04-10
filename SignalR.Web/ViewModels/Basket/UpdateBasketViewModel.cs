using SignalR.Web.ViewModels.BasketItem;
using SignalR.Web.ViewModels.RestaurantTable;

namespace SignalR.Web.ViewModels.Basket;

public class UpdateBasketViewModel
{
    public int Id { get; set; }
    public ICollection<UpdateBasketItemViewModel> BasketItems { get; set; }
    public ResultRestaurantTableViewModel RestaurantTable { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}