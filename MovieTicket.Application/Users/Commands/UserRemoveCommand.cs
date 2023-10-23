using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Users.Commands
{
    public class UserRemoveCommand : IRequest<User>
    {
        public int Id { get; set; }

        public UserRemoveCommand( int id )
        {
            this.Id = id;
        }
    }
}
