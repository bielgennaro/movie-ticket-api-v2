using MediatR;

using MovieTicket.Application.Users.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Users.Handlers
{
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UserUpdateCommandHandler( IUserRepository userRepository )
        {
            this._userRepository = userRepository;
        }

        public async Task<User> Handle( UserUpdateCommand request, CancellationToken cancellationToken )
        {
            var user = await this._userRepository.GetUserByIdAsync( request.Id ) ?? throw new ApplicationException( "User not found" );

            user.Update( request.Email, request.Password, request.IsAdmin );

            return await this._userRepository.UpdateUserAsync( user );
        }
    }
}
