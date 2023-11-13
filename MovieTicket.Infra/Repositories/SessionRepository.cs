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
        private readonly ApplicationDbContext _dbContext;

        public SessionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            return await _dbContext.Sessions.ToListAsync();
        }

        public async Task<Session> GetSessionByIdAsync(int id)
        {
            return await _dbContext.Sessions.FindAsync(id);
        }

        public async Task<Session> InsertSessionAsync(Session session)
        {
            var newSession = new Session(session.Room, session.AvailableTickets, session.Date, session.Price, session.MovieId);
            _dbContext.Sessions.Add(newSession);
            await _dbContext.SaveChangesAsync();
            return session;
        }

        public async Task UpdateSessionAsync(Session session, int id)
        {
            var existingSession = await _dbContext.Sessions.FindAsync(id);

            if (existingSession != null)
            {
                existingSession.AvailableTickets = session.AvailableTickets;
                existingSession.MovieId = session.MovieId;
                existingSession.Price = session.Price;
                existingSession.Room = session.Room;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Session> DeleteSessionAsync(Session session)
        {
            _dbContext.Sessions.Remove(session);
            await _dbContext.SaveChangesAsync();
            return session;
        }

        public async Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(int movieId)
        {
            return await _dbContext.Sessions
                .Where(s => s.MovieId == movieId)
                .ToListAsync();
        }
    }
}
