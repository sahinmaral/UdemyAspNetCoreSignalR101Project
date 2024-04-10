using AutoMapper;
using SignalR.Dto.SocialMediaAccount;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class SocialMediaAccountMappingProfile:Profile
{
    public SocialMediaAccountMappingProfile()
    {
        CreateMap<SocialMediaAccount, ResultSocialMediaAccountDto>().ReverseMap();
        CreateMap<SocialMediaAccount, CreateSocialMediaAccountDto>().ReverseMap();
        CreateMap<SocialMediaAccount, GetSocialMediaAccountDto>().ReverseMap();
        CreateMap<SocialMediaAccount, UpdateSocialMediaAccountDto>().ReverseMap();
    }
}