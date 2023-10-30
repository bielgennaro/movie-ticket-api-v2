#region

using MediatR;

using MovieTicket.Application.Users.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Users.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler( IUserRepository userRepository )
    {
        this._userRepository = userRepository;
    }

    public async Task<User> Handle( GetUserByIdQuery request, CancellationToken cancellationToken )
    {
        return await this._userRepository.GetUserByIdAsync( request.Id ) ?? throw new ApplicationException( "User not found" );
    }
}