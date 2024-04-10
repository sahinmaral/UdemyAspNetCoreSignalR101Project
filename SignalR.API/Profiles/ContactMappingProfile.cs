using AutoMapper;
using SignalR.Dto.Contact;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class ContactMappingProfile:Profile
{
    public ContactMappingProfile()
    {
        CreateMap<Contact, ResultContactDto>().ReverseMap();
        CreateMap<Contact, CreateContactDto>().ReverseMap();
        CreateMap<Contact, GetContactDto>().ReverseMap();
        CreateMap<Contact, UpdateContactDto>().ReverseMap();
    }
}