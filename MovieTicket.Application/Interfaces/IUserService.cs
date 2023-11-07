#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers();

    Task<UserDto> GetUserById(int id);

    Task<UserDto> AddUser(UserDto userDto);

    Task UpdateUser(UserDto userDto);

    Task<UserDto> GetUserByEmailAsync(string email);

    Task RemoveUser(int id);
}