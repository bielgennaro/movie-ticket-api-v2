using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Sessions.Queries
{
    public class GetSessionsQuery : IRequest<IList<Session>>
    {
    }
}
