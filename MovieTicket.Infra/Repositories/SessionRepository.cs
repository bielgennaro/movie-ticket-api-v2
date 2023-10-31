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
        return await this._sessionContext.Sessions.ToListAsync();
    }

    public async Task<Session> GetSessionByIdAsync( int id )
    {
        return await this._sessionContext.Sessions.FindAsync( id );
    }

    public async Task<Session> InsertSessionAsync( Session session )
    {
        this._sessionContext.Add( session );
        await this._sessionContext.SaveChangesAsync();
        return session;
    }

    public async Task<Session> UpdateSessionAsync( Session session )
    {
        this._sessionContext.Update( session );
        await this._sessionContext.SaveChangesAsync();
        return session;
    }

    public async Task<Session> DeleteSessionAsync( Session session )
    {
        this._sessionContext.Remove( session );
        await this._sessionContext.SaveChangesAsync();
        return session;
    }

    public async Task<IEnumerable<Session>> GetSessionsByMovieIdAsync( int movieId )
    {
        return await this._sessionContext.Sessions.Where( s => s.MovieId == movieId ).ToListAsync();
    }
}