#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface ISessionService
{
    Task<IEnumerable<SessionDto>> GetSessionsAsync();

    Task<SessionDto> GetSessionByIdAsync( int id );

    Task<SessionDto> CreateSessionAsync( SessionDto sessionDto );

    Task UpdateSessionAsync( SessionDto sessionDto );

    Task DeleteSessionAsync( int id );
}