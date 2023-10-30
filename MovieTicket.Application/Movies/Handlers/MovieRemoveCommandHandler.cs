#region

using MediatR;

using MovieTicket.Application.Movies.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Movies.Handlers;

public class MovieRemoveCommandHandler : IRequestHandler<MovieRemoveCommand, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public MovieRemoveCommandHandler( IMovieRepository movieRepository )
    {
        this._movieRepository = movieRepository;
    }

    public async Task<Movie> Handle( MovieRemoveCommand request, CancellationToken cancellationToken )
    {
        var movie = await this._movieRepository.GetMovieByIdAsync( request.Id ) ??
                    throw new ApplicationException( "Movie not found" );

        return await this._movieRepository.DeleteMovieAsync( movie );
    }
}