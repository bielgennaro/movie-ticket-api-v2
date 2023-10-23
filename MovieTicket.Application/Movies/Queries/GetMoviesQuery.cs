using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Movies.Queries
{
    public class GetMoviesQuery : IRequest<List<Movie>>
    {
    }
}
