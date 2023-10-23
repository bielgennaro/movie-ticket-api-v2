using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Tickets.Queries
{
    public class GetTicketByIdQuery : IRequest<Ticket>
    {
        public int Id { get; set; }

        public GetTicketByIdQuery( int id )
        {
            this.Id = id;
        }
    }
}
