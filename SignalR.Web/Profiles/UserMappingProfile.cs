using AutoMapper;
using SignalR.Entity.Concrete;
using SignalR.Web.ViewModels.User;

namespace SignalR.Web.Profiles;

public class UserMappingProfile:Profile
{
    public UserMappingProfile()
    {
        CreateMap<RegisterUserViewModel, User>();
        CreateMap<LoginUserViewModel, User>();
    }
}