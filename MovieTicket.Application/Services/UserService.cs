#region

using AutoMapper;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository,
        IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await userRepository.GetUsersAsync();
        var usersDto = mapper.Map<IEnumerable<UserDto>>(users);
        return usersDto;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await userRepository.GetUserByIdAsync(id);
        var userDto = mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<UserDto> AddUser(UserDto userDto)
    {
        var user = mapper.Map<User>(userDto);
        var newUser = await userRepository.InsertUserAsync(user);
        var newUserDto = mapper.Map<UserDto>(newUser);
        return newUserDto;
    }

    public async Task UpdateUser(UserDto userDto)
    {
        var user = mapper.Map<User>(userDto);
        await userRepository.UpdateUserAsync(user);
    }

    public async Task RemoveUser(int id)
    {
        var user = userRepository.GetUserByIdAsync(id).Result;
        await userRepository.DeleteUserAsync(user);
    }
}