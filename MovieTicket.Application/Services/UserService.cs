using AutoMapper;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService( IUserRepository userRepository,
            IMapper mapper )
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await this.userRepository.GetUsersAsync();
            var usersDto = this.mapper.Map<IEnumerable<UserDto>>( users );
            return usersDto;
        }

        public async Task<UserDto> GetUserByIdAsync( int id )
        {
            var user = await this.userRepository.GetUserByIdAsync( id );
            var userDto = this.mapper.Map<UserDto>( user );
            return userDto;
        }

        public async Task<UserDto> CreateUserAsync( UserDto userDto )
        {
            var user = this.mapper.Map<User>( userDto );
            var newUser = await this.userRepository.InsertUserAsync( user );
            var newUserDto = this.mapper.Map<UserDto>( newUser );
            return newUserDto;
        }

        public async Task UpdateUserAsync( UserDto userDto )
        {
            var user = this.mapper.Map<User>( userDto );
            await this.userRepository.UpdateUserAsync( user );
        }

        public async Task DeleteUserAsync( int id )
        {
            var user = this.userRepository.GetUserByIdAsync( id ).Result;
            await this.userRepository.DeleteUserAsync( user );
        }
    }
}
