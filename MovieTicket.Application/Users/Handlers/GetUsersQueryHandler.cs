#region

using MediatR;

using MovieTicket.Application.Users.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Users.Handlers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUsersAsync();
    }
}