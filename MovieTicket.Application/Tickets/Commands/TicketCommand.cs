#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Tickets.Commands;

public abstract class TicketCommand : IRequest<Ticket>
{
    public int SessionId { get; set; }
    public Session Session { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}