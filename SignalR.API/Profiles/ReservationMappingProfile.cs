using AutoMapper;
using SignalR.Dto.Reservation;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class ReservationMappingProfile:Profile
{
    public ReservationMappingProfile()
    {
        CreateMap<Reservation, ResultReservationDto>().ReverseMap();
        CreateMap<Reservation, CreateReservationDto>().ReverseMap();
        CreateMap<Reservation, GetReservationDto>().ReverseMap();
        CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
    }
}