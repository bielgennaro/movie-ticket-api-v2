#region

using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

#endregion

namespace MovieTicket.Infra.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            return await _dbContext.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _dbContext.Tickets.FindAsync(id);
        }

        public async Task<Ticket> InsertTicketAsync(Ticket ticket)
        {
            _dbContext.Add(ticket);
            await _dbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicketAsync(Ticket ticket, int id)
        {
            var existingTicket = await _dbContext.Tickets.FindAsync(id);

            if (existingTicket != null)
            {
                existingTicket.UserId = ticket.UserId;
                existingTicket.SessionId = ticket.SessionId;

                await _dbContext.SaveChangesAsync();
            }

            return existingTicket;
        }

        public async Task<Ticket> DeleteTicketAsync(Ticket ticket)
        {
            _dbContext.Tickets.Remove(ticket);
            await _dbContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync(int userId)
        {
            return await _dbContext.Tickets
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsBySessionIdAsync(int sessionId)
        {
            return await _dbContext.Tickets
                .Where(t => t.SessionId == sessionId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAndSessionIdAsync(int userId, int sessionId)
        {
            return await _dbContext.Tickets
                .Where(t => t.UserId == userId && t.SessionId == sessionId)
                .ToListAsync();
        }
    }
}