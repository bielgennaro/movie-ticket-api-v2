using Microsoft.EntityFrameworkCore;

using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

namespace MovieTicket.Infra.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        readonly ApplicationDbContext _movieContext;

        public MovieRepository( ApplicationDbContext movieContext )
        {
            this._movieContext = movieContext;
        }

        public async Task<Movie> DeleteMovieAsync( Movie movie )
        {
            this._movieContext.Remove( movie );
            await this._movieContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> GetMovieByIdAsync( int id )
        {
            return await this._movieContext.Movies.FindAsync( id );
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await this._movieContext.Movies.ToListAsync();
        }

        public async Task<Movie> InsertMovieAsync( Movie movie )
        {
            this._movieContext.Add( movie );
            await this._movieContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> UpdateMovieAsync( Movie movie )
        {
            this._movieContext.Update( movie );
            await this._movieContext.SaveChangesAsync();
            return movie;
        }
    }
}
