#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTickets();

        Task<TicketDto> GetTicketById(int id);

        Task<TicketDto> CreateTicket(TicketDtoRequest ticketDto);

        Task UpdateTicket(TicketDtoRequest ticketDto, int id);

        Task DeleteTicket(int id);
    }
}