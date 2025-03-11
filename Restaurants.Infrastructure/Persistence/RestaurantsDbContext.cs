using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;
internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> option): DbContext(option)
{

    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dished { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dished)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);
    }
}