using AutoMapper;
using SignalR.Dto.DiscountOfDay;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class DiscountOfDayMappingProfile:Profile
{
    public DiscountOfDayMappingProfile()
    {
        CreateMap<DiscountOfDay, ResultDiscountOfDayDto>().ReverseMap();
        CreateMap<DiscountOfDay, CreateDiscountOfDayDto>().ReverseMap();
        CreateMap<DiscountOfDay, GetDiscountOfDayDto>().ReverseMap();
        CreateMap<DiscountOfDay, UpdateDiscountOfDayDto>().ReverseMap();
    }
}