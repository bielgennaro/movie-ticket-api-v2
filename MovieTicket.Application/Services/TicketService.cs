﻿#region

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

    public TicketService( IMediator mediator, IMapper mapper )
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
    {
        var ticketsQuery = new GetTicketsQuery();

        var result = await this._mediator.Send( ticketsQuery ) ?? throw new ApplicationException( "Tickets not found" );

        return this._mapper.Map<IEnumerable<TicketDto>>( result );
    }

    public async Task<TicketDto> GetTicketByIdAsync( int id )
    {
        var ticketQuery = new GetTicketByIdQuery( id );

        var result = await this._mediator.Send( ticketQuery ) ?? throw new ApplicationException( "Ticket not found" );

        return this._mapper.Map<TicketDto>( result );
    }

    public async Task<TicketDto> CreateTicketAsync( TicketDto ticketDto )
    {
        var ticketCommand = this._mapper.Map<TicketCreateCommand>( ticketDto );

        var result = await this._mediator.Send( ticketCommand );

        return this._mapper.Map<TicketDto>( result );
    }

    public async Task UpdateTicketAsync( TicketDto ticketDto )
    {
        var ticketCommand = this._mapper.Map<TicketUpdateCommand>( ticketDto );

        await this._mediator.Send( ticketCommand );
    }

    public async Task DeleteTicketAsync( int id )
    {
        var ticketCommand = new TicketRemoveCommand( id );

        await this._mediator.Send( ticketCommand );
    }
}