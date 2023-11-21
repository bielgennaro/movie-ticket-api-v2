#region

using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.WebApi.MovieTicket.Application.Dtos;

#endregion

namespace MovieTicket.API.Controllers
{
    [ApiController]
    [Route("sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService, ILogger<SessionController> logger)
        {
            _sessionService = sessionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetSessions()
        {
            try
            {
                var sessions = await _sessionService.GetSessions();
                _logger.LogInformation("Sessions retrieved successfully.");
                return Ok(sessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sessions.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetSessionById(int id)
        {
            try
            {
                var session = await _sessionService.GetSessionById(id);

                if (session == null)
                {
                    _logger.LogInformation($"Session with ID {id} not found.");
                    return NotFound();
                }

                return Ok(session);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving session with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<SessionDto>> CreateSession(SessionDtoRequest sessionDto)
        {
            try
            {
                var newSession = await _sessionService.CreateSession(sessionDto);
                _logger.LogInformation($"Session created successfully with ID {newSession.MovieId}.");
                return CreatedAtAction(nameof(GetSessionById), new { Movie = sessionDto.Movie.Id, sessionDto.Movie.Title }, newSession);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating session.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSession(SessionDtoRequest sessionDto, int id)
        {
            try
            {
                await _sessionService.UpdateSession(sessionDto, id);
                _logger.LogInformation($"Session with ID {id} updated successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating session with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            try
            {
                await _sessionService.DeleteSession(id);
                _logger.LogInformation($"Session with ID {id} deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting session with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}