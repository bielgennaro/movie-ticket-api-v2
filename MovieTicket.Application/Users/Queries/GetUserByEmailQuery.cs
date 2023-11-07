using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Users.Queries;

public class GetUserByEmailQuery : IRequest<User>
{
    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }

    public string Email { get; set; }
}