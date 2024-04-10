using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Context;

public class DiscountOfDayInitializer
{
    public static void Initialize(EntityTypeBuilder<DiscountOfDay> discountOfDayBuilder)
    {
        var discountOfDay1 = new DiscountOfDay
        {
            Id = 1,
            Title = "Lezzetli Perşembeler",
            Amount = 20,
            ImageUrl = "/feane/images/o1.jpg",
            Description = "Perşembe günleri için hamburger kategorisinde indirim"
        };
        
        var discountOfDay2 = new DiscountOfDay
        {
            Id = 2,
            Title = "Pizza Günleri",
            Amount = 15,
            ImageUrl = "/feane/images/o2.jpg",
            Description = "Belirlenen günlerde pizza kategorisinde indirim"
        };

        discountOfDayBuilder.HasData(discountOfDay1, discountOfDay2);
    }
}