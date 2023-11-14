#region

using Microsoft.EntityFrameworkCore;

using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

#endregion

namespace MovieTicket.Infra.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _dbContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies.FindAsync(id);
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            var newMovie = new Movie(movie.Gender, movie.Synopsis, movie.Title, movie.Director, movie.BannerUrl);
            _dbContext.Movies.Add(newMovie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task UpdateAsync(Movie movie, int id)
        {
            var existingMovie = await _dbContext.Movies.FindAsync(id);

            if (existingMovie != null)
            {
                existingMovie.Gender = movie.Gender;
                existingMovie.Title = movie.Title;
                existingMovie.Synopsis = movie.Synopsis;
                existingMovie.Director = movie.Director;
                existingMovie.BannerUrl = movie.BannerUrl;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Movie> DeleteAsync(Movie movie)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }
    }
}