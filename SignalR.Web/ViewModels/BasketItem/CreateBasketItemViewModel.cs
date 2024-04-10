using SignalR.Dto.Product;
using SignalR.Web.ViewModels.Product;

namespace SignalR.Web.ViewModels.BasketItem;

public class CreateBasketItemViewModel
{
    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public ResultProductViewModel Product { get; set; }
}