#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<TicketDto>> GetTickets();

    Task<TicketDto> GetTicketById(int id);

    Task<TicketDto> CreateTicket(TicketDto ticketDto);

    Task UpdateTicket(TicketDto ticketDto, int id);

    Task DeleteTicket(int id);
}