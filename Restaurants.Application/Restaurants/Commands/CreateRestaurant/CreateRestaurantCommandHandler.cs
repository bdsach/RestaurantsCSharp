using Restaurants.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using Restaurants.Application.Users;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;
public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommand> logger,
    IMapper mapper,
    IRestaurantsRepository restaurantsRepository,
    IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        if (currentUser is null)
        {
            logger.LogWarning("No authenticated user found while attempting to create a restaurant.");
            throw new InvalidOperationException("Cannot Create restaurant without an authenticated user.");
        }

        logger.LogInformation("{UserName} [{UserId}] Creating a new restaurant {@Restaurant}", 
            currentUser.Email, 
            currentUser.Id,
            request);

        var restaurant = mapper.Map<Restaurant>(request);
        restaurant.OwnerId = currentUser.Id;

        int id = await restaurantsRepository.Create(restaurant);

        return id;
    }
}