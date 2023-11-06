#region

using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.WebApi.Controller;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("getallusers", Order = 1)]
    public async Task<ActionResult> GetUsersAsync()
    {
        try
        {
            var users = await _userService.GetUsersAsync();

            if (users == null) return NotFound("message: Nenhum usuário encontrado");

            return Ok(users);
        }
        catch (Exception e)
        {
            throw new Exception($"Erro ao buscar usuários: {e.Message}");
        }
    }
}