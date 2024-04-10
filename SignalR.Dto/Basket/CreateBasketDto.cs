using SignalR.Dto.BasketItem;
using SignalR.Dto.RestaurantTable;

namespace SignalR.Dto.Basket;

public class CreateBasketDto
{
    public ICollection<CreateBasketItemDto> BasketItems { get; set; }
    public ResultRestaurantTableDto RestaurantTable { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime Date { get; set; }
}