using MovieTicket.Domain.Entities;

namespace MovieTicket.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();

        Task<Movie> GetMovieByIdAsync( int id );

        Task<Movie> InsertMovieAsync( Movie movie );

        Task<Movie> UpdateMovieAsync( Movie movie );

        Task<Movie> DeleteMovieAsync( Movie movie );
    }
}