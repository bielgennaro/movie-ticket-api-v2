#region

using MovieTicket.Application.DTOs;
using MovieTicket.WebApi.MovieTicket.Application.Dtos;

#endregion

namespace MovieTicket.Application.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionDto>> GetSessions();

        Task<SessionDto> GetSessionById(int id);

        Task<SessionDtoRequest> CreateSession(SessionDtoRequest sessionDto);

        Task UpdateSession(SessionDtoRequest sessionDto, int id);

        Task DeleteSession(int id);
    }
}