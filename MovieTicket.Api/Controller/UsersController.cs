#region

using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);

        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto)
    {
        var newUser = await _userService.AddUser(userDto);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Email }, newUser);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
    {
        await _userService.UpdateUser(userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.RemoveUser(id);
        return NoContent();
    }
}