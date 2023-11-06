#region

using AutoMapper;
using MediatR;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Application.Users.Commands;
using MovieTicket.Application.Users.Queries;

#endregion

namespace MovieTicket.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UserService(IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var usersQuery = new GetUsersQuery();

        var result = await _mediator.Send(usersQuery);

        return _mapper.Map<IEnumerable<UserDto>>(result);
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var userQuery = new GetUserByIdQuery(id);

        var result = await _mediator.Send(userQuery) ?? throw new ApplicationException("User not found");

        return _mapper.Map<UserDto>(result);
    }

    public async Task<UserDto> CreateUserAsync(UserDto userDto)
    {
        var userCommand = _mapper.Map<UserCreateCommand>(userDto);

        var result = await _mediator.Send(userCommand);

        return _mapper.Map<UserDto>(result);
    }

    public async Task UpdateUserAsync(UserDto userDto)
    {
        var userCommand = _mapper.Map<UserUpdateCommand>(userDto);

        await _mediator.Send(userCommand);
    }

    public async Task DeleteUserAsync(int id)
    {
        var userCommand = new UserRemoveCommand(id);

        await _mediator.Send(userCommand);
    }
}