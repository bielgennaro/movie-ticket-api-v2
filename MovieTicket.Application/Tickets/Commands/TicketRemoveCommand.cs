#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Tickets.Commands;

public class TicketRemoveCommand : IRequest<Ticket>
{
    public TicketRemoveCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}