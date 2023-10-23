using MediatR;

using MovieTicket.Application.Movies.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Movies.Handlers
{
    public class MovieUpdateCommandHandler : IRequestHandler<MovieUpdateCommand, Movie>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieUpdateCommandHandler( IMovieRepository movieRepository )
        {
            this._movieRepository = movieRepository;
        }

        public async Task<Movie> Handle( MovieUpdateCommand request, CancellationToken cancellationToken )
        {
            var movie = await this._movieRepository.GetMovieByIdAsync( request.Id ) ?? throw new ApplicationException( "Movie not found" );

            movie.Update( request.Gender, request.Synopsis, request.Title, request.Director, request.BannerUrl );

            return await this._movieRepository.UpdateMovieAsync( movie );
        }
    }
}
