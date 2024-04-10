using AutoMapper;
using SignalR.Dto.About;
using SignalR.Dto.Basket;
using SignalR.Dto.BasketItem;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class BasketMappingProfile:Profile
{
    public BasketMappingProfile()
    {
        CreateMap<Basket, CreateBasketDto>().ReverseMap();
        CreateMap<Basket, ResultBasketDto>().ReverseMap();
        CreateMap<Basket, UpdateBasketDto>().ReverseMap();
        
        CreateMap<BasketItem, CreateBasketItemDto>().ReverseMap();
        CreateMap<BasketItem, ResultBasketItemDto>().ReverseMap();
        CreateMap<BasketItem, UpdateBasketItemDto>().ReverseMap();
    }
}