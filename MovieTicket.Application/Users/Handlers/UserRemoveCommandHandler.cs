﻿#region

using MediatR;
using MovieTicket.Application.Users.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Users.Handlers;

public class UserRemoveCommandHandler : IRequestHandler<UserRemoveCommand, User>
{
    private readonly IUserRepository _userRepository;

    public UserRemoveCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> Handle(UserRemoveCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id) ??
                   throw new ApplicationException("User not found");

        return await _userRepository.DeleteUserAsync(user);
    }
}