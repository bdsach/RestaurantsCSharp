using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteDish;
public class DeleteDishesRestaurantCommandHandler(
    ILogger<DeleteDishesRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository
    ) : IRequestHandler<DeleteDishesRestaurantCommand>
{
    public async Task Handle(DeleteDishesRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Removing all dishes from restaurant: {RestaurantId}", request.RestaurantId);

        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
        if (restaurant is null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        await dishesRepository.Delete(restaurant.Dishes);
    }
}