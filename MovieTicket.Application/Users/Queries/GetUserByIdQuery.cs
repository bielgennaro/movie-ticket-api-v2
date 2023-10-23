using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }

        public GetUserByIdQuery( int id )
        {
            this.Id = id;
        }
    }
}
