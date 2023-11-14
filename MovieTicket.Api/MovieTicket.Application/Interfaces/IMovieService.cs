#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetMovies();

        Task<MovieDto> GetById(int id);

        Task Create(MovieDtoRequest movieDto);

        Task Update(MovieDtoRequest movieDto, int id);

        Task Remove(int id);
    }
}