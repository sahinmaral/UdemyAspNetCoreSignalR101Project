using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using SignalR.Business.Abstract;
using SignalR.Dto.Notification;
using SignalR.Dto.Reservation;
using SignalR.Dto.RestaurantTable;

namespace SignalR.API.Hubs;

public class SignalRHub: Hub
{
    private readonly IMapper _mapper;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IOrderService _orderService;
    private readonly ICashRegisterService _cashRegisterService;
    private readonly IRestaurantTableService _restaurantTableService;
    private readonly IReservationService _reservationService;
    private readonly INotificationService _notificationService;
    
    public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, ICashRegisterService cashRegisterService, IRestaurantTableService restaurantTableService, IReservationService reservationService, IMapper mapper, INotificationService notificationService)
    {
        _mapper = mapper;
        _notificationService = notificationService;
        _categoryService = categoryService;
        _productService = productService;
        _orderService = orderService;
        _cashRegisterService = cashRegisterService;
        _restaurantTableService = restaurantTableService;
        _reservationService = reservationService;
    }

    public async Task SendStatistic()
    {
        var categoryCountDetailed = _categoryService.GetCategoryCountDetailed();
        await Clients.All.SendAsync("ReceiveCategoryCountDetailed",categoryCountDetailed);
        
        var productCount = _productService.Count();
        await Clients.All.SendAsync("ReceiveProductCount", productCount);

        var orderCountDetailed = _orderService.GetOrderCountDetailed();
        await Clients.All.SendAsync("ReceiveOrderCountDetailed", orderCountDetailed);
        
        var filteredProductsWithHamburgerCategory = _productService.CountByCategoryName("Hamburger");
        await Clients.All.SendAsync("ReceiveCountProductWithHamburgerCategory", filteredProductsWithHamburgerCategory);
        
        var filteredProductsWithIcecekCategory = _productService.CountByCategoryName("İçecek");
        await Clients.All.SendAsync("ReceiveCountProductWithIcecekCategory", filteredProductsWithIcecekCategory);
        
        var productsAveragePrice = _productService.GetAveragePriceOfAllProducts();
        await Clients.All.SendAsync("ReceiveProductsAveragePrice", productsAveragePrice.ToString("0.00") + "\u20ba");
        
        var minimumPriceProductName = _productService.GetMinimumPriceProductName();
        await Clients.All.SendAsync("ReceiveMinimumPriceProductName", minimumPriceProductName);
        
        var maximumPriceProductName = _productService.GetMaximumPriceProductName();
        await Clients.All.SendAsync("ReceiveMaximumPriceProductName", maximumPriceProductName);
        
        var totalRestaurantTableCount = _restaurantTableService.Count();
        await Clients.All.SendAsync("ReceiveTotalRestaurantTableCount", totalRestaurantTableCount);
        
        var averagePriceWithHamburgerCategory = _productService.GetAveragePriceWithHamburgerCategory();
        await Clients.All.SendAsync("ReceiveAveragePriceWithHamburgerCategory", averagePriceWithHamburgerCategory.ToString("0.00") + "\u20ba");

        var lastOrderTotalPrice = _orderService.GetLastOrderTotalPrice();
        await Clients.All.SendAsync("ReceiveLastOrderTotalPrice", lastOrderTotalPrice.ToString("0.00") + "\u20ba");
        
        var todayEarning = _orderService.GetTodayEarning();
        await Clients.All.SendAsync("ReceiveTodayEarning", todayEarning.ToString("0.00") + "\u20ba");
        
        var totalCashRegisterAmount = _cashRegisterService.GetTotalCashRegisterAmount();
        await Clients.All.SendAsync("ReceiveTotalCashRegisterAmount", totalCashRegisterAmount.ToString("0.00") + "\u20ba");
    }

    public async Task SendReservation()
    {
        var reservations = _reservationService.GetAll();
        await Clients.All.SendAsync("ReceiveReservations",_mapper.Map<List<ResultReservationDto>>(reservations));
    }
    
    public async Task SendNotificationCountByStatusTrue()
    {
        var notificationCount = _notificationService.Count(notification => notification.Status);
        await Clients.All.SendAsync("ReceiveNotificationCountByStatusTrue",notificationCount);
    }
    
    public async Task SendNotifications()
    {
        var notifications = _notificationService.GetAll();
        await Clients.All.SendAsync("ReceiveNotifications",_mapper.Map<List<ResultNotificationDto>>(notifications));
    }
    
    public async Task SendRestaurantTable()
    {
        var restaurantTables = _restaurantTableService.GetAll();
        await Clients.All.SendAsync("ReceiveRestaurantTables",_mapper.Map<List<ResultRestaurantTableDto>>(restaurantTables));
    }
}