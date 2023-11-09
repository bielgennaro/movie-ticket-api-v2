#region

using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.WebApi.Controller;

[Route("api/users")]
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

    [HttpGet]
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

    [HttpGet("{id}")]
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

    [HttpPost("create")]
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
            return CreatedAtRoute("", new { email = userDto.Email }, userDto);
        }
        catch (Exception e)
        {
            _logger.LogError("Erro ao criar usuário: exception");
            throw new Exception($"Erro ao criar usuário: {e.Message}");
        }
    }

    [HttpPut("update/{id}")]
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

    [HttpDelete("delete/{id}")]
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

            return NoContent();
            _logger.LogInformation("Usuário deletado com sucesso");
        }
        catch (Exception e)
        {
            _logger.LogError("Erro ao deletar usuário: exception");
            throw new Exception($"Erro ao deletar usuário: {e.Message}");
        }
    }
}