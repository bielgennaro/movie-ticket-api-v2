#region

using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.WebApi.MovieTicket.Application.Dtos;

#endregion

namespace MovieTicket.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                _logger.LogInformation("Users retrieved successfully.");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving users.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);

                if (user == null)
                {
                    _logger.LogInformation($"User with ID {id} not found.");
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving user with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> AddUser(UserDtoRequest userDto)
        {
            try
            {
                var newUser = await _userService.AddUser(userDto);
                _logger.LogInformation($"User created successfully with ID {newUser.Id}.");
                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(UserDtoRequest userDto, int id)
        {
            try
            {
                await _userService.UpdateUser(userDto, id);
                _logger.LogInformation($"User with ID {id} updated successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating user with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("auth")]
        public async Task<ActionResult<UserDto>> AuthenticateUser(UserDtoLoginRequest userDto)
        {
            try
            {
                var user = await _userService.AuthenticateUser(userDto);

                if (user == null)
                {
                    _logger.LogInformation($"User with email {userDto.Email} not found.");
                    return NotFound();
                }

                _logger.LogInformation("Usuário autenticado com sucesso.");
                return Ok($"Usuário {userDto.Email} autenticado com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving user with email {userDto.Email}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            try
            {
                await _userService.RemoveUser(id);
                _logger.LogInformation($"User with ID {id} deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting user with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}