#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Movies.Queries;

public class GetMoviesQuery : IRequest<IEnumerable<Movie>>
{
}