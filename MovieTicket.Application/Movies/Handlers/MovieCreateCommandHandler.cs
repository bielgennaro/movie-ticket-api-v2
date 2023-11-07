#region

using MediatR;

using MovieTicket.Application.Movies.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Movies.Handlers;

public class MovieCreateCommandHandler : IRequestHandler<MovieCreateCommand, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public MovieCreateCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Movie> Handle(MovieCreateCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie(request.Gender, request.Synopsis, request.Title, request.Director, request.BannerUrl);

        return await _movieRepository.InsertMovieAsync(movie);
    }
}