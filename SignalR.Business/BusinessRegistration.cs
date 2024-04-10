using Microsoft.Extensions.DependencyInjection;
using SignalR.Business.Abstract;
using SignalR.Business.Concrete;

namespace SignalR.Business;

public static class BusinessRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IDiscountOfDayService, DiscountOfDayManager>();
        services.AddScoped<IHighlightService, HighlightManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IReservationService, ReservationManager>();
        services.AddScoped<ISocialMediaAccountService, SocialMediaAccountManager>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IOrderDetailService, OrderDetailManager>();
        services.AddScoped<ICashRegisterService, CashRegisterManager>();
        services.AddScoped<IRestaurantTableService, RestaurantTableManager>();
        services.AddScoped<IAdvertisementService, AdvertisementManager>();
        services.AddScoped<IBasketService, BasketManager>();
        services.AddScoped<INotificationService, NotificationManager>();
        return services;
    } 
}