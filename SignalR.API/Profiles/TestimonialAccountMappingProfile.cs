using AutoMapper;
using SignalR.Dto.Testimonial;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class TestimonialMappingProfile:Profile
{
    public TestimonialMappingProfile()
    {
        CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
    }
}