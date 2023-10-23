using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Movies.Queries
{
    public class GetMovieByIdQuery : IRequest<Movie>
    {
        public int Id { get; set; }

        public GetMovieByIdQuery( int id )
        {
            this.Id = id;
        }
    }
}
