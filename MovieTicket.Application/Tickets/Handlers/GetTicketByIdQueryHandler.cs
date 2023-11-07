#region

using MediatR;

using MovieTicket.Application.Tickets.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Tickets.Handlers;

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Ticket>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketByIdQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        return await _ticketRepository.GetTicketByIdAsync(request.Id) ??
               throw new ApplicationException("Ticket not found");
    }
}