#region

using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

#endregion

namespace MovieTicket.Infra.Data.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly ApplicationDbContext _movieContext;

    public MovieRepository(ApplicationDbContext movieContext)
    {
        _movieContext = movieContext;
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        return await _movieContext.Movies.ToListAsync();
    }

    public async Task<Movie> CreateAsync(Movie movie)
    {
        _movieContext.Add(movie);
        await _movieContext.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie> DeleteAsync(Movie movie)
    {
        _movieContext.Remove(movie);
        await _movieContext.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        return await _movieContext.Movies.FindAsync(id);
    }

    public async Task<Movie> UpdateAsync(Movie movie)
    {
        _movieContext.Update(movie);
        await _movieContext.SaveChangesAsync();
        return movie;
    }
}