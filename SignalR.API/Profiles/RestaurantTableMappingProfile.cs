using AutoMapper;
using SignalR.Dto.RestaurantTable;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class RestaurantTableMappingProfile:Profile
{
    public RestaurantTableMappingProfile()
    {
        CreateMap<RestaurantTable, ResultRestaurantTableDto>().ReverseMap();
    }
}