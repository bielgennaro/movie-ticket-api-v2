#region

using MovieTicket.Application.DTOs;

#endregion

namespace MovieTicket.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto> GetUserById(int id);

        Task<UserDto> AddUser(UserDtoRequest userDto);

        Task<UserDto> AuthenticateUser(UserDtoRequest userDto);

        Task UpdateUser(UserDtoRequest userDto, int id);

        Task RemoveUser(int id);
    }
}