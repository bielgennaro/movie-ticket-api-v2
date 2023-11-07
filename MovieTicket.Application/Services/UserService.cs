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

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var userQuery = new GetUsersQuery();

        if (userQuery == null)
        {
            throw new ApplicationException($"Entity could not be loaded.");
        }

        var result = await _mediator.Send(userQuery);

        return _mapper.Map<IEnumerable<UserDto>>(result);
    }

    public async Task<UserDto> GetUserById(int id)
    {
        var userByIdQuery = new GetUserByIdQuery(id);

        if (userByIdQuery == null)
        {
            throw new ApplicationException($"Entity could not be loaded.");
        }

        var result = await _mediator.Send(userByIdQuery);

        return _mapper.Map<UserDto>(result);
    }

    //TODO: Implementar o método de adicionar usuário
    public async Task<UserDto> AddUser(UserDto userDto)
    {
        var userCreateCommand = _mapper.Map<UserCreateCommand>(userDto);

        var user = await _mediator.Send(userCreateCommand);

        return _mapper.Map<UserDto>(user);
    }

    public async Task UpdateUser(UserDto userDto)
    {
        var userCommand = _mapper.Map<UserUpdateCommand>(userDto);

        await _mediator.Send(userCommand);
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        var userQuery = new GetUserByEmailQuery(email);

        var result = await _mediator.Send(userQuery) ?? throw new ApplicationException("User not found");

        return _mapper.Map<UserDto>(result);
    }

    public async Task RemoveUser(int id)
    {
        var userRemoveCommand = new UserRemoveCommand(id);

        if (userRemoveCommand == null)
        {
            throw new ApplicationException($"Entity could not be loaded.");
        }

        await _mediator.Send(userRemoveCommand);
    }
}