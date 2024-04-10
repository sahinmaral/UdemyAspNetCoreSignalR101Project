using AutoMapper;
using SignalR.Dto.Advertisement;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class AdvertisementProfile:Profile
{
    public AdvertisementProfile()
    {
        CreateMap<Advertisement, ResultAdvertisementDto>().ReverseMap();
    }
}