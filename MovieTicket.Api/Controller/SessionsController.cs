#region

using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionsController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SessionDto>>> GetSessions()
    {
        var sessions = await _sessionService.GetSessions();
        return Ok(sessions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SessionDto>> GetSessionById(int id)
    {
        var session = await _sessionService.GetSessionById(id);

        if (session == null) return NotFound();

        return Ok(session);
    }

    [HttpPost]
    public async Task<ActionResult<SessionDto>> CreateSession([FromBody] SessionDto sessionDto)
    {
        var newSession = await _sessionService.CreateSession(sessionDto);
        return CreatedAtAction(nameof(GetSessionById), new { id = newSession.MovieId }, newSession);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSession([FromBody] SessionDto sessionDto)
    {
        await _sessionService.UpdateSession(sessionDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        await _sessionService.DeleteSession(id);
        return NoContent();
    }
}