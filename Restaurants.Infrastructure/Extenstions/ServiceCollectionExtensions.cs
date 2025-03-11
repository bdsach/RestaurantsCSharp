using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeder;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDb");
        services.AddDbContext<RestaurantsDbContext>(option => option.UseNpgsql(connectionString));
        services.AddScoped<IRestaurantsSeeder, RestaurantsSeeder>();
    }

}