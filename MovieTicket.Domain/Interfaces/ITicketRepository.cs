﻿using MovieTicket.Domain.Entities;

namespace MovieTicket.Domain.Interfaces;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetTicketsAsync();

    Task<Ticket> GetTicketByIdAsync( int id );

    Task<Ticket> InsertTicketAsync( Ticket ticket );

    Task<Ticket> UpdateTicketAsync( Ticket ticket );

    Task<Ticket> DeleteTicketAsync( Ticket ticket );

    Task<IEnumerable<Ticket>> GetTicketsByUserIdAsync( int userId );

    Task<IEnumerable<Ticket>> GetTicketsBySessionIdAsync( int sessionId );

    Task<IEnumerable<Ticket>> GetTicketsByUserIdAndSessionIdAsync( int userId, int sessionId );
}