using SignalR.Dto.Product;

namespace SignalR.Dto.BasketItem;

public class ResultBasketItemDto
{
    public int Id { get; set; }
    public ResultProductDto Product { get; set; }
    public int Count { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}