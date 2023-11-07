#region

using MediatR;

using MovieTicket.Application.Users.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Users.Handlers;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
{
    private readonly IUserRepository _userRepository;

    public UserCreateCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        User user = new User(request.Email, request.Password, request.IsAdmin);

        if (user == null)
        {
            throw new ApplicationException($"Error creating entity");
        }
        else
        {
            return await _userRepository.InsertUserAsync(user);
        }
    }
}