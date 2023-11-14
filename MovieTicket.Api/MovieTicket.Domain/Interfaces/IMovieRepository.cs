#region

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();

        Task<Movie> GetByIdAsync(int id);

        Task<Movie> CreateAsync(Movie movie);

        Task UpdateAsync(Movie movie, int id);

        Task<Movie> DeleteAsync(Movie movie);
    }
}