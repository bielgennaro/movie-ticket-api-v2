using MediatR;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Sessions.Commands
{
    public abstract class SessionCommand : IRequest<Session>
    {
        public string Room { get; set; }
        public int AvailableTickets { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
