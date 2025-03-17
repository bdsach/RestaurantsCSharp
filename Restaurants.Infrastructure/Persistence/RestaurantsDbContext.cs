using Restaurants.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Restaurants.Infrastructure.Persistence;
internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> option)
: IdentityDbContext<User>(option)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);
        
        modelBuilder.Entity<User>()
            .HasMany(o => o.OwnedRestaurant)
            .WithOne(r => r.Owner)
            .HasForeignKey(r => r.OwnerId);
    }
}