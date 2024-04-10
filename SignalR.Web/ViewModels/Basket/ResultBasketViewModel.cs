using SignalR.Web.ViewModels.BasketItem;
using SignalR.Web.ViewModels.RestaurantTable;

namespace SignalR.Web.ViewModels.Basket;

public class ResultBasketViewModel
{
    public int Id { get; set; }
    public ICollection<ResultBasketItemViewModel> BasketItems { get; set; }
    public ResultRestaurantTableViewModel RestaurantTable { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}