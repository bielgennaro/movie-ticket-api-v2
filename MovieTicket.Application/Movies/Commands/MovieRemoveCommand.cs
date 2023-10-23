using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Movies.Commands
{
    public class MovieRemoveCommand : IRequest<Movie>
    {
        public int Id { get; set; }

        public MovieRemoveCommand( int id )
        {
            this.Id = id;
        }
    }
}
