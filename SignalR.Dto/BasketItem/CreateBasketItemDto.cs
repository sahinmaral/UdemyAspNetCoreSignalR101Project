using SignalR.Dto.Product;

namespace SignalR.Dto.BasketItem;

public class CreateBasketItemDto
{
    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public ResultProductDto Product { get; set; }
}