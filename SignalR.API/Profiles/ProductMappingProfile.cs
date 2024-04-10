using AutoMapper;
using SignalR.Dto.Product;
using SignalR.Entity.Concrete;

namespace SignalR.API.Profiles;

public class ProductMappingProfile:Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, ResultProductWithCategoryDto>()
            .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.Category.Name))
            .ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
    }
}