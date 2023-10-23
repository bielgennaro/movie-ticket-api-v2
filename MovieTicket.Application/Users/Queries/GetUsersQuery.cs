using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<IList<User>>
    {

    }
}
