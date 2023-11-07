#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Tickets.Queries;

public class GetTicketsQuery : IRequest<IList<Ticket>>
{
}