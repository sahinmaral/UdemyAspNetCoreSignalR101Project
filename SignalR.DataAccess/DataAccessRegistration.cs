using Microsoft.Extensions.DependencyInjection;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete.Repository.EntityFramework;

namespace SignalR.DataAccess;

public static class DataAccessRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<IAboutDal, EfAboutDal>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IDiscountOfDayDal, EfDiscountOfDayDal>();
        services.AddScoped<IHighlightDal, EfHighlightDal>();
        services.AddScoped<IProductDal, EfProductDal>();
        services.AddScoped<IReservationDal, EfReservationDal>();
        services.AddScoped<ISocialMediaAccountDal, EfSocialMediaAccountDal>();
        services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        services.AddScoped<IOrderDal, EfOrderDal>();
        services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
        services.AddScoped<ICashRegisterDal, EfCashRegisterDal>();
        services.AddScoped<IRestaurantTableDal, EfRestaurantTableDal>();
        services.AddScoped<IAdvertisementDal, EfAdvertisementDal>();
        services.AddScoped<IBasketDal, EfBasketDal>();
        services.AddScoped<INotificationDal, EfNotificationDal>();
        return services;
    } 
}