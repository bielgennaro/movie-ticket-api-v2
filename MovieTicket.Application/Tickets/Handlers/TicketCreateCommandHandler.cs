using MediatR;

using MovieTicket.Application.Tickets.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Tickets.Handlers
{
    internal class TicketCreateCommandHandler : IRequestHandler<TicketCreateCommand, Ticket>
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketCreateCommandHandler( ITicketRepository ticketRepository )
        {
            this._ticketRepository = ticketRepository;
        }

        public async Task<Ticket> Handle( TicketCreateCommand request, CancellationToken cancellationToken )
        {
            var ticket = new Ticket( request.SessionId, request.UserId );

            return ticket == null
                ? throw new ApplicationException( "There was an error creating the user" )
                : await this._ticketRepository.InsertTicketAsync( ticket );
        }
    }
}
