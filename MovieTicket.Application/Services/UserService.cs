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
        GetUsersQuery userQuery = new GetUsersQuery();

        if (userQuery == null)
        {
            throw new ApplicationException($"Entity could not be loaded.");
        }

        IEnumerable<Domain.Entities.User> result = await _mediator.Send(userQuery);

        return _mapper.Map<IEnumerable<UserDto>>(result);
    }

    public async Task<UserDto> GetUserById(int id)
    {
        GetUserByIdQuery userByIdQuery = new GetUserByIdQuery(id);

        if (userByIdQuery == null)
        {
            throw new ApplicationException($"Entity could not be loaded.");
        }

        Domain.Entities.User result = await _mediator.Send(userByIdQuery);

        return _mapper.Map<UserDto>(result);
    }

    //TODO: Implementar o método de adicionar usuário
    public async Task<UserDto> AddUser(UserDto userDto)
    {
        UserCreateCommand userCommand = _mapper.Map<UserCreateCommand>(userDto);

        Domain.Entities.User result = await _mediator.Send(userCommand);

        return _mapper.Map<UserDto>(result);
    }

    public async Task UpdateUser(UserDto userDto)
    {
        UserUpdateCommand userCommand = _mapper.Map<UserUpdateCommand>(userDto);

        await _mediator.Send(userCommand);
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        GetUserByEmailQuery userQuery = new GetUserByEmailQuery(email);

        Domain.Entities.User result = await _mediator.Send(userQuery) ?? throw new ApplicationException("User not found");

        return _mapper.Map<UserDto>(result);
    }

    public async Task RemoveUser(int id)
    {
        UserRemoveCommand userRemoveCommand = new UserRemoveCommand(id);

        if (userRemoveCommand == null)
        {
            throw new ApplicationException($"Entity could not be loaded.");
        }

        await _mediator.Send(userRemoveCommand);
    }
}