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

        [HttpGet("{id}")]
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
        
        [HttpPost("create")]
        public async Task<ActionResult<TicketDto>> CreateTicketAsync([FromBody] TicketDto ticketDto)
        {
            try
            {
                _logger.LogInformation("Criando ingresso");
                var ticket = await _ticketService.CreateTicket(ticketDto);

                if (ticket == null)
                {
                    _logger.LogError("Erro ao criar ingresso");
                    return BadRequest("Erro ao criar ingresso");
                }

                _logger.LogInformation("Ingresso criado com sucesso");
                return CreatedAtRoute("", new { id = ticket.Id }, ticket);
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao criar ingresso");
                throw new Exception($"Erro ao criar ingresso: {e.Message}");
            }
        }
        
        [HttpPut("update/{id}")]
        public async Task<ActionResult<TicketDto>> UpdateTicketAsync(int id, [FromBody] TicketDto ticketDto)
        {
            try
            {
                var ticket = await _ticketService.GetTicketById(id);
                
                if (ticket == null)
                {
                    _logger.LogError($"Erro ao atualizar ingresso {id}");
                    return NotFound($"Erro ao atualizar ingresso de id: {id}");
                }
                
                _logger.LogInformation($"Atualizando ingresso {id}");
                await _ticketService.UpdateTicket(ticketDto);
                
                _logger.LogInformation($"Ingresso {id} atualizado com sucesso");
                return Ok(ticketDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao atualizar ingresso {id}");
                throw new Exception($"Erro ao atualizar ingresso: {e.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteTicketAsync(int id)
        {
            try
            {
                var ticket = await _ticketService.GetTicketById(id);

                if (ticket == null)
                {
                    _logger.LogError($"Erro ao deletar ingresso {id}");
                    return NotFound($"Erro ao deletar ingresso de id: {id}");
                }

                _logger.LogInformation($"Deletando ingresso {id}");
                await _ticketService.DeleteTicket(id);

                _logger.LogInformation($"Ingresso {id} deletado com sucesso");
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao deletar ingresso {id}");
                throw new Exception($"Erro ao deletar ingresso: {e.Message}");
            }
        }
    }
}
