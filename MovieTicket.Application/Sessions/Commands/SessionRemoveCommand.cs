#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Sessions.Commands;

public class SessionRemoveCommand : IRequest<Session>
{
    public SessionRemoveCommand( int id )
    {
        this.Id = id;
    }

    public int Id { get; set; }
}