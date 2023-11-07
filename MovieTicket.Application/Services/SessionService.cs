#region

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

    public SessionService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SessionDto>> GetSessions()
    {
        GetSessionsQuery sessionsQuery = new GetSessionsQuery();

        IList<Domain.Entities.Session> result = await _mediator.Send(sessionsQuery) ?? throw new ApplicationException("Sessions not found");

        return _mapper.Map<IEnumerable<SessionDto>>(result);
    }

    public async Task<SessionDto> GetSessionById(int id)
    {
        GetSessionByIdQuery sessionQuery = new GetSessionByIdQuery(id);

        Domain.Entities.Session result = await _mediator.Send(sessionQuery) ?? throw new ApplicationException("Session not found");

        return _mapper.Map<SessionDto>(result);
    }

    public async Task<SessionDto> CreateSession(SessionDto sessionDto)
    {
        SessionCreateCommand sessionCommand = _mapper.Map<SessionCreateCommand>(sessionDto);

        Domain.Entities.Session result = await _mediator.Send(sessionCommand);

        return _mapper.Map<SessionDto>(result);
    }

    public async Task UpdateSession(SessionDto sessionDto)
    {
        SessionUpdateCommand sessionCommand = _mapper.Map<SessionUpdateCommand>(sessionDto);

        await _mediator.Send(sessionCommand);
    }

    public async Task DeleteSession(int id)
    {
        SessionRemoveCommand sessionCommand = new SessionRemoveCommand(id);

        Domain.Entities.Session result = await _mediator.Send(sessionCommand);
    }
}