#region

using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketDto>>> GetTickets()
    {
        var tickets = await _ticketService.GetTickets();
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDto>> GetTicketById(int id)
    {
        var ticket = await _ticketService.GetTicketById(id);

        if (ticket == null) return NotFound();

        return Ok(ticket);
    }

    [HttpPost("create")]
    public async Task<ActionResult<TicketDto>> CreateTicket([FromBody] TicketDto ticketDto)
    {
        var newTicket = await _ticketService.CreateTicket(ticketDto);
        return CreatedAtAction(nameof(GetTicketById), new { user_id = newTicket.UserId }, newTicket);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateTicket([FromBody] TicketDto ticketDto)
    {
        await _ticketService.UpdateTicket(ticketDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        await _ticketService.DeleteTicket(id);
        return NoContent();
    }
}