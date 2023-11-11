#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMovies();

    Task<MovieDto> GetById(int id);

    Task Create(MovieDto movieDto);

    Task Update(MovieDto movieDto);

    Task Remove(int id);
}