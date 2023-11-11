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
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await _userRepository.GetUsersAsync();
        var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
        return usersDto;
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }

    public async Task<UserDto> AddUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        var newUser = await _userRepository.InsertUserAsync(user);
        var newUserDto = _mapper.Map<UserDto>(newUser);
        return newUserDto;
    }

    public async Task UpdateUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        await _userRepository.UpdateUserAsync(user);
    }

    public async Task RemoveUser(int id)
    {
        var user = _userRepository.GetUserByIdAsync(id).Result;
        await _userRepository.DeleteUserAsync(user);
    }
}