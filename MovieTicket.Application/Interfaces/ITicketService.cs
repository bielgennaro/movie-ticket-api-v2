#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<TicketDto>> GetTicketsAsync();

    Task<TicketDto> GetTicketByIdAsync(int id);

    Task<TicketDto> CreateTicketAsync(TicketDto ticketDto);

    Task UpdateTicketAsync(TicketDto ticketDto);

    Task DeleteTicketAsync(int id);
}