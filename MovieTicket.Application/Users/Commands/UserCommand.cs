#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Users.Commands;

public abstract class UserCommand : IRequest<User>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}