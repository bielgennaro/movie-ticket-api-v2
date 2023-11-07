﻿#region

using AutoMapper;

using MediatR;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Application.Sessions.Commands;
using MovieTicket.Application.Sessions.Queries;

#endregion

namespace MovieTicket.Application.Services;

public class SessionService : ISessionService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public SessionService( IMediator mediator, IMapper mapper )
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<SessionDto>> GetSessionsAsync()
    {
        var sessionsQuery = new GetSessionsQuery();

        var result = await this._mediator.Send( sessionsQuery ) ?? throw new ApplicationException( "Sessions not found" );

        return this._mapper.Map<IEnumerable<SessionDto>>( result );
    }

    public async Task<SessionDto> GetSessionByIdAsync( int id )
    {
        var sessionQuery = new GetSessionByIdQuery( id );

        var result = await this._mediator.Send( sessionQuery ) ?? throw new ApplicationException( "Session not found" );

        return this._mapper.Map<SessionDto>( result );
    }

    public async Task<SessionDto> CreateSessionAsync( SessionDto sessionDto )
    {
        var sessionCommand = this._mapper.Map<SessionCreateCommand>( sessionDto );

        var result = await this._mediator.Send( sessionCommand );

        return this._mapper.Map<SessionDto>( result );
    }

    public async Task UpdateSessionAsync( SessionDto sessionDto )
    {
        var sessionCommand = this._mapper.Map<SessionUpdateCommand>( sessionDto );

        await this._mediator.Send( sessionCommand );
    }

    public async Task DeleteSessionAsync( int id )
    {
        var sessionCommand = new SessionRemoveCommand( id );

        var result = await this._mediator.Send( sessionCommand );
    }
}