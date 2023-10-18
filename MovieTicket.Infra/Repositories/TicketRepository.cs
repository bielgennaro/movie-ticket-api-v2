using Microsoft.EntityFrameworkCore;

using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

namespace MovieTicket.Infra.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _ticketContext;

        public TicketRepository( ApplicationDbContext ticketContext )
        {
            this._ticketContext = ticketContext;
        }

        public async Task<Ticket> DeleteTicketAsync( Ticket ticket )
        {
            this._ticketContext.Remove( ticket );
            await this._ticketContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> GetTicketByIdAsync( int id )
        {
            return await this._ticketContext.Tickets.FindAsync( id );
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            return await this._ticketContext.Tickets.ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsBySessionIdAsync( int sessionId )
        {
            return await this._ticketContext.Tickets.Where( t => t.SessionId == sessionId ).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAndSessionIdAsync( int userId, int sessionId )
        {
            return await this._ticketContext.Tickets.Where( t => t.UserId == userId && t.SessionId == sessionId ).ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync( int userId )
        {
            return await this._ticketContext.Tickets.Where( t => t.UserId == userId ).ToListAsync();
        }

        public async Task<Ticket> InsertTicketAsync( Ticket ticket )
        {
            this._ticketContext.Add( ticket );
            await this._ticketContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicketAsync( Ticket ticket )
        {
            this._ticketContext.Update( ticket );
            await this._ticketContext.SaveChangesAsync();
            return ticket;
        }
    }
}
