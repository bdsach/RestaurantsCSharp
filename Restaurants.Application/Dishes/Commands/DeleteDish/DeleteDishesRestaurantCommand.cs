using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDish;

public class DeleteDishesRestaurantCommand(int restaurantId) : IRequest
{
    public int RestaurantId = restaurantId;
}