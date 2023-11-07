#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMovies();

    Task<MovieDto> GetMovieById(int id);

    Task<MovieDto> CreateMovie(MovieDto movieDto);

    Task UpdateMovie(MovieDto movieDto);

    Task DeleteMovie(int id);
}