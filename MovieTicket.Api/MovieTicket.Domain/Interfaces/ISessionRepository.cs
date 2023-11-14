#region

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Domain.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<Session>> GetSessionsAsync();

        Task<Session> GetSessionByIdAsync(int id);

        Task<Session> InsertSessionAsync(Session session);

        Task UpdateSessionAsync(Session session, int id);

        Task<Session> DeleteSessionAsync(Session session);

        Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(int movieId);
    }
}