#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMoviesAsync();

    Task<MovieDto> GetMovieByIdAsync(int id);

    Task<MovieDto> CreateMovieAsync(MovieDto movieDto);

    Task UpdateMovieAsync(MovieDto movieDto);

    Task DeleteMovieAsync(int id);
}