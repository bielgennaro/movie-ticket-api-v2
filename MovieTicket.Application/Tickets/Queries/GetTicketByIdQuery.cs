#region

using MediatR;
using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Tickets.Queries;

public class GetTicketByIdQuery : IRequest<Ticket>
{
    public GetTicketByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}