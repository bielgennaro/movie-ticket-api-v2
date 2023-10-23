using MediatR;

using MovieTicket.Application.Users.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Users.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateCommandHandler( IUserRepository userRepository )
        {
            this._userRepository = userRepository;
        }

        public async Task<User> Handle( UserCreateCommand request, CancellationToken cancellationToken )
        {
            var user = new User( request.Email, request.Password, request.IsAdmin );

            return user == null
                ? throw new ApplicationException( "There was an error creating the user" )
                : await this._userRepository.InsertUserAsync( user );
        }
    }
}
