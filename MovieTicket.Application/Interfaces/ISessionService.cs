#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface ISessionService
{
    Task<IEnumerable<SessionDto>> GetSessions();

    Task<SessionDto> GetSessionById(int id);

    Task<SessionDto> CreateSession(SessionDto sessionDto);

    Task UpdateSession(SessionDto sessionDto, int id);

    Task DeleteSession(int id);
}