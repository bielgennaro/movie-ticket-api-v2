using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Tickets.Commands
{
    public class TicketRemoveCommand : IRequest<Ticket>
    {
        public int Id { get; set; }

        public TicketRemoveCommand( int id )
        {
            this.Id = id;
        }
    }
}
