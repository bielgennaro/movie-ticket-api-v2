using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

namespace MovieTicket.Infra.Data.Repositories
{
    internal class TicketRepository : ITicketRepository
    {
        ApplicationDbContext _ticketContext;

        public TicketRepository( ApplicationDbContext ticketContext )
        {
            this._ticketContext = ticketContext;
        }

        public async Task<Ticket> DeleteTicketAsync( Ticket ticket )
        {
            _ticketContext.Remove( ticket );
            await _ticketContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> GetTicketByIdAsync( int id )
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsBySessionIdAsync( int sessionId )
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAndSessionIdAsync( int userId, int sessionId )
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync( int userId )
        {
            
        }

        public async Task<Ticket> InsertTicketAsync( Ticket ticket )
        {
            _ticketContext.Add( ticket );
            await _ticketContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> UpdateTicketAsync( Ticket ticket )
        {
            _ticketContext.Update( ticket );
            await _ticketContext.SaveChangesAsync();
            return ticket;
        }
    }
}
