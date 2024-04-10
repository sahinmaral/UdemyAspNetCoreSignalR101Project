using AutoMapper;
using SignalR.Dto.About;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class AboutMappingProfile:Profile
{
    public AboutMappingProfile()
    {
        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, GetAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
    }
}