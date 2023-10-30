#region

using MediatR;

using MovieTicket.Application.Tickets.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Tickets.Handlers;

internal class TicketUpdateCommandHandler : IRequestHandler<TicketUpdateCommand, Ticket>
{
    private readonly ITicketRepository _ticketRepository;

    public TicketUpdateCommandHandler( ITicketRepository ticketRepository )
    {
        this._ticketRepository = ticketRepository;
    }

    public async Task<Ticket> Handle( TicketUpdateCommand request, CancellationToken cancellationToken )
    {
        var ticket = await this._ticketRepository.GetTicketByIdAsync( request.Id ) ??
                     throw new ApplicationException( "Ticket not found" );

        ticket.Update( request.SessionId, request.UserId );

        await this._ticketRepository.UpdateTicketAsync( ticket );

        return ticket;
    }
}