using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Sessions.Queries
{
    public class GetSessionByIdQuery : IRequest<Session>
    {
        public int Id { get; set; }

        public GetSessionByIdQuery( int id )
        {
            this.Id = id;
        }
    }
}
