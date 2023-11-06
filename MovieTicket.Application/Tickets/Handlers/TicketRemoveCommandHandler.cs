#region

using MediatR;
using MovieTicket.Application.Tickets.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Tickets.Handlers;

internal class TicketRemoveCommandHandler : IRequestHandler<TicketRemoveCommand, Ticket>
{
    private readonly ITicketRepository _ticketRepository;

    public TicketRemoveCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> Handle(TicketRemoveCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetTicketByIdAsync(request.Id) ??
                     throw new ApplicationException("Ticket not found");

        return await _ticketRepository.DeleteTicketAsync(ticket);
    }
}