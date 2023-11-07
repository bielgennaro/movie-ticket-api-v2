using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

namespace MovieTicket.WebApi.Controller
{
    [Route("tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly ILogger<TicketsController> _logger;
        public TicketsController(ITicketService ticketService, ILogger<TicketsController> logger)
        {
            _ticketService = ticketService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsAsync()
        {
            try
            {
                IEnumerable<TicketDto> tickets = await _ticketService.GetTickets();

                if (tickets == null)
                {
                    _logger.LogInformation("Nenhum ingresso encontrado");
                    return NotFound("Message: Nenhum ingresso encontrado");
                }

                _logger.LogInformation("Busca de ingressos realizada com sucesso");
                return Ok(tickets);

            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar ingressos");
                throw new Exception($"Erro ao buscar ingressos: {e.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<TicketDto>> GetTicketByIdAsync(int id)
        {
            try
            {
                var tickets = await _ticketService.GetTicketById(id);

                if (tickets == null)
                {
                    _logger.LogError($"Erro ao buscar ingresso {id}");
                    return NotFound($"Erro ao buscar ingresso de id: {id}");
                }
                _logger.LogInformation($"Buscando ingresso {id}");
                return Ok(tickets);

            } catch(Exception e)
            {
                _logger.LogError($"Erro ao buscar ingresso {id}");
                throw new Exception($"Erro ao buscar ticket: {e.Message}");
            }
        }
    }
}
