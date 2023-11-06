#region

using MediatR;
using MovieTicket.Application.Users.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Users.Handlers;

public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, User>
{
    private readonly IUserRepository _userRepository;

    public UserUpdateCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id) ??
                   throw new ApplicationException("User not found");

        user.Update(request.Email, request.Password, request.IsAdmin);

        return await _userRepository.UpdateUserAsync(user);
    }
}