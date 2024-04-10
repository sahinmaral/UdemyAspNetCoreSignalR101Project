using SignalR.Web.ViewModels.Product;

namespace SignalR.Web.ViewModels.BasketItem;

public class UpdateBasketItemViewModel
{
    public int Id { get; set; }
    public ResultProductViewModel Product { get; set; }
    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}