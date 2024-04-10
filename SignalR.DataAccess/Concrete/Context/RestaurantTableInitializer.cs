using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Context;

public static class RestaurantTableInitializer
{
    public static void Initialize(EntityTypeBuilder<RestaurantTable> restaurantTableBuilder)
    {
        var salonTables = new[]
        {
            new RestaurantTable { Id = 1, Name = "Salon 1", Status = true },
            new RestaurantTable { Id = 2, Name = "Salon 2", Status = true },
            new RestaurantTable { Id = 3, Name = "Salon 3", Status = true },
            new RestaurantTable { Id = 4, Name = "Salon 4", Status = true },
            new RestaurantTable { Id = 5, Name = "Salon 5", Status = true },
            new RestaurantTable { Id = 6, Name = "Salon 6", Status = true },
            new RestaurantTable { Id = 7, Name = "Salon 7", Status = true },
            new RestaurantTable { Id = 8, Name = "Salon 8", Status = true },
            new RestaurantTable { Id = 9, Name = "Salon 9", Status = true },
            new RestaurantTable { Id = 10, Name = "Salon 10", Status = true }
        };
        
        var terasTables = new[]
        {
            new RestaurantTable { Id = 11, Name = "Teras 1", Status = true },
            new RestaurantTable { Id = 12, Name = "Teras 2", Status = true },
            new RestaurantTable { Id = 13, Name = "Teras 3", Status = true },
            new RestaurantTable { Id = 14, Name = "Teras 4", Status = true },
            new RestaurantTable { Id = 15, Name = "Teras 5", Status = true },
            new RestaurantTable { Id = 16, Name = "Teras 6", Status = true },
            new RestaurantTable { Id = 17, Name = "Teras 7", Status = true },
            new RestaurantTable { Id = 18, Name = "Teras 8", Status = true },
            new RestaurantTable { Id = 19, Name = "Teras 9", Status = true },
            new RestaurantTable { Id = 20, Name = "Teras 10", Status = true }
        };


        restaurantTableBuilder.HasData(salonTables.Concat(terasTables));
    }
}