#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Movies.Commands;

public class MovieRemoveCommand : IRequest<Movie>
{
    public MovieRemoveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}