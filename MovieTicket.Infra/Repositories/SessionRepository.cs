#region

using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

#endregion

namespace MovieTicket.Infra.Data.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _sessionContext;

        public SessionRepository(ApplicationDbContext sessionContext)
        {
            _sessionContext = sessionContext;
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            return await _sessionContext.Sessions.ToListAsync();
        }

        public async Task<Session> GetSessionByIdAsync(int id)
        {
            return await _sessionContext.Sessions.FindAsync(id);
        }

        public async Task<Session> InsertSessionAsync(Session session)
        {
            _sessionContext.Add(session);
            await _sessionContext.SaveChangesAsync();
            return session;
        }

        public async Task UpdateSessionAsync(Session session, int id)
        {
            var existingSession = await _sessionContext.Sessions.FindAsync(id);

            if (existingSession != null)
            {
                existingSession.AvailableTickets = session.AvailableTickets;
                existingSession.MovieId = session.MovieId;
                existingSession.Price = session.Price;
                existingSession.Room = session.Room;

                await _sessionContext.SaveChangesAsync();
            }
        }

        public async Task<Session> DeleteSessionAsync(Session session)
        {
            _sessionContext.Sessions.Remove(session);
            await _sessionContext.SaveChangesAsync();
            return session;
        }

        public async Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(int movieId)
        {
            return await _sessionContext.Sessions
                .Where(s => s.MovieId == movieId)
                .ToListAsync();
        }
    }
}