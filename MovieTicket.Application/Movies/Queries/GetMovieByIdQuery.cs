#region

using MediatR;
using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Movies.Queries;

public class GetMovieByIdQuery : IRequest<Movie>
{
    public GetMovieByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}