#region

using MovieTicket.Application.DTOs;
using MovieTicket.WebApi.MovieTicket.Application.Dtos;

#endregion

namespace MovieTicket.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto> GetUserById(int id);

        Task<UserDto> AddUser(UserDtoRequest userDto);

        Task<UserDto> AuthenticateUser(UserDtoLoginRequest userDto);

        Task UpdateUser(UserDtoRequest userDto, int id);

        Task RemoveUser(int id);
    }
}