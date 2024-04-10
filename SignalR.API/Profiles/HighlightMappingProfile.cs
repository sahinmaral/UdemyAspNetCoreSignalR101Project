using AutoMapper;
using SignalR.Dto.Highlight;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class HighlightMappingProfile:Profile
{
    public HighlightMappingProfile()
    {
        CreateMap<Highlight, ResultHighlightDto>().ReverseMap();
        CreateMap<Highlight, CreateHighlightDto>().ReverseMap();
        CreateMap<Highlight, GetHighlightDto>().ReverseMap();
        CreateMap<Highlight, UpdateHighlightDto>().ReverseMap();
    }
}