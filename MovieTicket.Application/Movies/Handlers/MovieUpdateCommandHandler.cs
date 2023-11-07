#region

using MediatR;

using MovieTicket.Application.Movies.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Movies.Handlers;

public class MovieUpdateCommandHandler : IRequestHandler<MovieUpdateCommand, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public MovieUpdateCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<Movie> Handle(MovieUpdateCommand request, CancellationToken cancellationToken)
    {
        Movie movie = await _movieRepository.GetMovieByIdAsync(request.Id) ??
                    throw new ApplicationException("Movie not found");

        movie.Update(request.Gender, request.Synopsis, request.Title, request.Director, request.BannerUrl);

        return await _movieRepository.UpdateMovieAsync(movie);
    }
}