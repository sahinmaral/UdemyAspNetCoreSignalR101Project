using AutoMapper;
using SignalR.Dto.Notification;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class NotificationMappingProfile:Profile
{
    public NotificationMappingProfile()
    {
        CreateMap<Notification, ResultNotificationDto>().ReverseMap();
        CreateMap<Notification, CreateNotificationDto>().ReverseMap();
        CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
    }
}