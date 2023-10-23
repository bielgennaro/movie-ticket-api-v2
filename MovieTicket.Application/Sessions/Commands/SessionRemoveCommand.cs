using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Sessions.Commands
{
    public class SessionRemoveCommand : IRequest<Session>
    {
        public int Id { get; set; }

        public SessionRemoveCommand( int id )
        {
            this.Id = id;
        }
    }
}
