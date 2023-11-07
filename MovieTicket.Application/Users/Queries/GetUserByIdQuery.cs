#region

using MediatR;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Users.Queries;

public class GetUserByIdQuery : IRequest<User>
{
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}