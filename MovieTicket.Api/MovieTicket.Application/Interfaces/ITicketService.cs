using MovieTicket.Application.DTOs;


namespace MovieTicket.Application.Interfaces
{
    public interface ITicketService
    {
        Task<TicketDto> GetTicketById(int id);

        Task<TicketDto> CreateTicket(TicketDtoRequest ticketDto);

        Task UpdateTicket(TicketDtoRequest ticketDto, int id);

        Task DeleteTicket(int id);

        Task<IEnumerable<TicketDto>> GetTicketsByUserIdAsync(int userId);

        Task<IEnumerable<TicketDto>> GetTicketsBySessionIdAsync(int sessionId);

        Task<IEnumerable<TicketDto>> GetTicketsByUserIdAndSessionIdAsync(int userId, int sessionId);
    }
}