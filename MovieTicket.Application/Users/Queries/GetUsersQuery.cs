#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Users.Queries;

public class GetUsersQuery : IRequest<IEnumerable<User>>
{
}