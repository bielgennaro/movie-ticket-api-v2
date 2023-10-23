using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Tickets.Queries
{
    public class GetTicketsQuery : IRequest<IList<Ticket>>
    {
    }
}
