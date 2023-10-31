#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Sessions.Queries;

public class GetSessionsQuery : IRequest<IList<Session>>
{
}