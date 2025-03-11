using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants;

public class RestaurantsService(IRestaurantsRepository restaurantsRepository,
ILogger<RestaurantsService> logger): IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("getting all restaurants");

        var restaurants = await restaurantsRepository.GetAllAsync();

        var restaurantsDto = restaurants.Select(RestaurantDto.FromEntity);

        return restaurantsDto!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation("getting restaurant by id");
        var restaurant = await restaurantsRepository.GetByIdAsync(id);
        var restaurantDto = RestaurantDto.FromEntity(restaurant);

        return restaurantDto;
    }
}