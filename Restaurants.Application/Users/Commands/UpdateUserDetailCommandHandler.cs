using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Commands;

public class UpdateUserDetailCommandHandler(ILogger<UpdateUserDetailCommandHandler> logger,
    IUserContext userContext,
    IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailCommand>
{
    public async Task Handle(UpdateUserDetailCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        logger.LogInformation("Updating user: {UserId} with {@Request}", user!.Id, request);

        var dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken);

        if (dbUser is null)
        {
            throw new NotFoundException(nameof(User), user.Id);
        }

        dbUser.DateOfBirth = request.DateOfBirth;
        dbUser.Nationality = request.Nationality;

        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}