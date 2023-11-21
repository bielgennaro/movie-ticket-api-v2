#region

using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.API.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService, ILogger<TicketController> logger)
        {
            _ticketService = ticketService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetTicketById(int id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketById(id);

                if (ticket == null)
                {
                    _logger.LogInformation($"Ticket with ID {id} not found.");
                    return NotFound();
                }

                return Ok(ticket);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving ticket with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<TicketDto>> CreateTicket(TicketDtoRequest ticketDto)
        {
            try
            {
                var newTicket = await _ticketService.CreateTicket(ticketDto);
                _logger.LogInformation($"Ticket created successfully with ID {newTicket.Id}.");
                return CreatedAtAction(nameof(GetTicketById), new { id = newTicket.Id }, newTicket);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ticket.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTicket(TicketDtoRequest ticketDto, int id)
        {
            try
            {
                await _ticketService.UpdateTicket(ticketDto, id);
                _logger.LogInformation($"Ticket with ID {id} updated successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating ticket with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            try
            {
                await _ticketService.DeleteTicket(id);
                _logger.LogInformation($"Ticket with ID {id} deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting ticket with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsByUserId(int userId)
        {
            try
            {
                var tickets = await _ticketService.GetTicketsByUserIdAsync(userId);
                _logger.LogInformation($"Tickets for user with ID {userId} retrieved successfully.");
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving tickets for user with ID {userId}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("session/{sessionId}")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsBySessionId(int sessionId)
        {
            try
            {
                var tickets = await _ticketService.GetTicketsBySessionIdAsync(sessionId);
                _logger.LogInformation($"Tickets for session with ID {sessionId} retrieved successfully.");
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving tickets for session with ID {sessionId}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("user/{userId}/session/{sessionId}")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsByUserIdAndSessionId(int userId, int sessionId)
        {
            try
            {
                var tickets = await _ticketService.GetTicketsByUserIdAndSessionIdAsync(userId, sessionId);
                _logger.LogInformation($"Tickets for user with ID {userId} and session with ID {sessionId} retrieved successfully.");
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving tickets for user with ID {userId} and session with ID {sessionId}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
