#region

using AutoMapper;

using MediatR;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Application.Tickets.Commands;
using MovieTicket.Application.Tickets.Queries;

#endregion

namespace MovieTicket.Application.Services;

public class TicketService : ITicketService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public TicketService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
    {
        GetTicketsQuery ticketsQuery = new GetTicketsQuery();

        IList<Domain.Entities.Ticket> result = await _mediator.Send(ticketsQuery) ?? throw new ApplicationException("Tickets not found");

        return _mapper.Map<IEnumerable<TicketDto>>(result);
    }

    public async Task<TicketDto> GetTicketByIdAsync(int id)
    {
        GetTicketByIdQuery ticketQuery = new GetTicketByIdQuery(id);

        Domain.Entities.Ticket result = await _mediator.Send(ticketQuery) ?? throw new ApplicationException("Ticket not found");

        return _mapper.Map<TicketDto>(result);
    }

    public async Task<TicketDto> CreateTicketAsync(TicketDto ticketDto)
    {
        TicketCreateCommand ticketCommand = _mapper.Map<TicketCreateCommand>(ticketDto);

        Domain.Entities.Ticket result = await _mediator.Send(ticketCommand);

        return _mapper.Map<TicketDto>(result);
    }

    public async Task UpdateTicketAsync(TicketDto ticketDto)
    {
        TicketUpdateCommand ticketCommand = _mapper.Map<TicketUpdateCommand>(ticketDto);

        await _mediator.Send(ticketCommand);
    }

    public async Task DeleteTicketAsync(int id)
    {
        TicketRemoveCommand ticketCommand = new TicketRemoveCommand(id);

        await _mediator.Send(ticketCommand);
    }
}