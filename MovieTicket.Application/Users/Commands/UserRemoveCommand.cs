﻿#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Users.Commands;

public class UserRemoveCommand : IRequest<User>
{
    public UserRemoveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}