using MediatR;

using MovieTicket.Application.Movies.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Movies.Handlers
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesQueryHandler( IMovieRepository movieRepository )
        {
            this._movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle( GetMoviesQuery request, CancellationToken cancellationToken )
        {
            return await this._movieRepository.GetMoviesAsync();
        }
    }
}
