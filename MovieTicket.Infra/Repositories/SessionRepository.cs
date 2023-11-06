#region

using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

#endregion

namespace MovieTicket.Infra.Data.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly ApplicationDbContext _sessionContext;

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

    public async Task<Session> UpdateSessionAsync(Session session)
    {
        _sessionContext.Update(session);
        await _sessionContext.SaveChangesAsync();
        return session;
    }

    public async Task<Session> DeleteSessionAsync(Session session)
    {
        _sessionContext.Remove(session);
        await _sessionContext.SaveChangesAsync();
        return session;
    }

    public async Task<IEnumerable<Session>> GetSessionsByMovieIdAsync(int movieId)
    {
        return await _sessionContext.Sessions.Where(s => s.MovieId == movieId).ToListAsync();
    }
}