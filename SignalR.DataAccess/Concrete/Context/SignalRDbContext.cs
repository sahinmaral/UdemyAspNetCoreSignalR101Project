using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalR.Entity.Concrete;

namespace SignalR.DataAccess.Concrete.Context;

public class SignalRDbContext : IdentityDbContext<User, Role, int>
{
    public SignalRDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Ignore<IdentityUserLogin<int>>();
        modelBuilder.Ignore<IdentityUserToken<int>>();
        modelBuilder.Ignore<IdentityRoleClaim<int>>();
        
        modelBuilder.Entity<Role>().ToTable("Roles");

        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString()
            });

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 2, Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() });

        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");

        RestaurantTableInitializer.Initialize(modelBuilder.Entity<RestaurantTable>());
        AdvertisementInitializer.Initialize(modelBuilder.Entity<Advertisement>());
        DiscountOfDayInitializer.Initialize(modelBuilder.Entity<DiscountOfDay>());
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<DiscountOfDay> DiscountOfDays { get; set; }
    public DbSet<Highlight> Highlights { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<SocialMediaAccount> SocialMediaAccounts { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<CashRegister> CashRegisters { get; set; }
    public DbSet<RestaurantTable> RestaurantTables { get; set; }
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Notification> Notifications { get; set; }
}