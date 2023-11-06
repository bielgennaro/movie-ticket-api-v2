#region

using MediatR;
using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Sessions.Queries;

public class GetSessionByIdQuery : IRequest<Session>
{
    public GetSessionByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}