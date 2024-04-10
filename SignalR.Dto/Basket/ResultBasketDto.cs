using SignalR.Dto.BasketItem;
using SignalR.Dto.RestaurantTable;

namespace SignalR.Dto.Basket;

public class ResultBasketDto
{
    public int Id { get; set; }
    public ICollection<ResultBasketItemDto> BasketItems { get; set; }
    public ResultRestaurantTableDto RestaurantTable { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}