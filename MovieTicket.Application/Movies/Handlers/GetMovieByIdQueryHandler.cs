#region

using MediatR;

using MovieTicket.Application.Movies.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Movies.Handlers;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public GetMovieByIdQueryHandler( IMovieRepository movieRepository )
    {
        this._movieRepository = movieRepository;
    }

    public async Task<Movie> Handle( GetMovieByIdQuery request, CancellationToken cancellationToken )
    {
        return await this._movieRepository.GetMovieByIdAsync( request.Id ) ??
               throw new ApplicationException( "Movie not found" );
    }
}