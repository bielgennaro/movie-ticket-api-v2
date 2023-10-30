#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();

    Task<UserDto> GetUserByIdAsync( int id );

    Task<UserDto> CreateUserAsync( UserDto userDto );

    Task UpdateUserAsync( UserDto userDto );

    Task DeleteUserAsync( int id );
}