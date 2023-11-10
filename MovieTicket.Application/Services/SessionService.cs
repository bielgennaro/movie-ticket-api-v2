#region

using AutoMapper;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Services;

public class SessionService : ISessionService
{
    private readonly IMapper _mapper;
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository, IMapper mapper)
    {
        _sessionRepository = sessionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SessionDto>> GetSessions()
    {
        var sessions = await _sessionRepository.GetSessionsAsync();
        var sessionsDto = _mapper.Map<IEnumerable<SessionDto>>(sessions);
        return sessionsDto;
    }

    public async Task<SessionDto> GetSessionById(int id)
    {
        var session = await _sessionRepository.GetSessionByIdAsync(id);
        var sessionDto = _mapper.Map<SessionDto>(session);
        return sessionDto;
    }

    public async Task<SessionDto> CreateSession(SessionDto sessionDto)
    {
        var session = _mapper.Map<Session>(sessionDto);
        var newSession = await _sessionRepository.InsertSessionAsync(session);
        var newSessionDto = _mapper.Map<SessionDto>(newSession);
        return newSessionDto;
    }

    public async Task UpdateSession(SessionDto sessionDto)
    {
        var session = _mapper.Map<Session>(sessionDto);
        await _sessionRepository.UpdateSessionAsync(session);
    }

    public async Task DeleteSession(int id)
    {
        var session = _sessionRepository.GetSessionByIdAsync(id).Result;
        await _sessionRepository.DeleteSessionAsync(session);
    }
}