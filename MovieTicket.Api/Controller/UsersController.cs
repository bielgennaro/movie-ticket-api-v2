#region

using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.WebApi.Controller;

[Route("api/v1/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet("getallusers", Order = 1)]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync()
    {
        try
        {
            _logger.LogInformation("Buscando usuários");
            IEnumerable<UserDto> users = await _userService.GetUsers();

            if (users == null)
            {
                return NotFound("Message: Nenhum usuário encontrado");
            }

            _logger.LogInformation("Busca de usuários realizada com sucesso");
            return Ok(users);
        }
        catch (Exception e)
        {
            _logger.LogError("Erro ao buscar usuários ");
            throw new Exception($"Erro ao buscar usuários: {e.Message}");
        }
    }

    [HttpGet("getuserbyid/{id}", Order = 2)]
    public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
    {
        try
        {
            _logger.LogInformation("Buscando usuário");
            UserDto user = await _userService.GetUserById(id);

            if (user == null)
            {
                _logger.LogError("Erro ao buscar usuário: Nenhum usuário encontrado");
                return NotFound("Message: Nenhum usuário encontrado");
            }

            _logger.LogInformation("Busca de usuário realizada com sucesso");
            return Ok(user);
        }
        catch (Exception e)
        {
            _logger.LogError("Erro ao buscar usuário: exception");
            throw new Exception($"Erro ao buscar usuário: {e.Message}");
        }
    }

    [HttpPost("createuser", Order = 3)]
    public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] UserDto userDto)
    {
        try
        {
            if (userDto == null)
            {
                _logger.LogError("Erro ao criar usuário: Nenhum usuário encontrado");
                return BadRequest("Message: Erro ao criar usuário");
            }

            _logger.LogInformation("Criando usuário");
            await _userService.AddUser(userDto);

            _logger.LogInformation("Usuário criado com sucesso");
            return CreatedAtRoute("GetUsers", new { id = userDto.Id }, userDto);
        }
        catch (Exception e)
        {
            _logger.LogError("Erro ao criar usuário: exception");
            throw new Exception($"Erro ao criar usuário: {e.Message}");
        }
    }

    [HttpPut("updateuser/{id}", Order = 4)]
    public async Task<ActionResult> UpdateUserAsync(int id, [FromBody] UserDto userDto)
    {
        try
        {
            _logger.LogInformation("Atualizando usuário");
            UserDto user = await _userService.GetUserById(id);

            if (user == null)
            {
                _logger.LogError("Erro ao atualizar usuário: Nenhum usuário encontrado");
                return NotFound("Message: Nenhum usuário encontrado");
            }

            _logger.LogInformation("Atualizando usuário");
            await _userService.UpdateUser(userDto);

            _logger.LogInformation("Usuário atualizado com sucesso");
            return Ok("Message: Usuário atualizado com sucesso");
        }
        catch (Exception e)
        {
            _logger.LogError("Erro ao atualizar usuário: exception");
            throw new Exception($"Erro ao atualizar usuário: {e.Message}");
        }
    }

    [HttpDelete("deleteuser/{id}", Order = 5)]
    public async Task<ActionResult> DeleteUserAsync(int id)
    {
        try
        {
            UserDto user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound("message: Nenhum usuário encontrado");
            }

            await _userService.RemoveUser(id);

            return Ok("message: Usuário deletado com sucesso");
        }
        catch (Exception e)
        {
            _logger.LogError("Erro ao deletar usuário: exception");
            throw new Exception($"Erro ao deletar usuário: {e.Message}");
        }
    }

    [HttpPost("login", Order = 7)]
    public async Task<ActionResult> LoginAsync([FromBody] UserDto userDto)
    {
        try
        {
            _logger.LogInformation("Tentando realizar login");
            UserDto user = await _userService.GetUserByEmailAsync(userDto.Email);

            if (user == null)
            {
                _logger.LogError("Erro ao realizar login: Nenhum usuário encontrado");
                return NotFound("Message: Nenhum usuário encontrado");
            }

            if (user.Password != userDto.Password)
            {
                _logger.LogTrace("Senha incorreta");
                return BadRequest("Message: Senha incorreta");
            }

            _logger.LogInformation($"Usuário logado com sucesso: {userDto.Email}");
            return Ok("Message: Login realizado com sucesso");
        }
        catch (Exception e)
        {
            _logger.LogError($"Erro ao realizar login do usuário: {userDto.Email}");
            throw new Exception($"Erro ao realizar login: {e.Message}");
        }
    }
}