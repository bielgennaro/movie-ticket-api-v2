using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

namespace MovieTicket.WebApi.Controller
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly ILogger<SessionsController> _logger;

        public SessionsController(ISessionService sessionService, ILogger<SessionsController> logger)
        {
            _sessionService = sessionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetSessionsAsync()
        {
            try
            {
                IEnumerable<SessionDto> sessions = await _sessionService.GetSessions();

                if (sessions == null)
                {
                    _logger.LogInformation("Nenhuma sessão encontrada");
                    return NotFound("Message: Nenhuma sessão encontrada");
                }

                _logger.LogInformation("Busca de sessões realizada com sucesso");
                return Ok(sessions);

            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar sessões");
                throw new Exception($"Erro ao buscar sessões: {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetSessionByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation("Buscando sessões");
                SessionDto sessions = await _sessionService.GetSessionById(id);

                if (sessions == null)
                {
                    _logger.LogError("Erro ao buscar sessões: Nenhuma sessão encontrada");
                    return NotFound("Message: Nenhuma sessão encontrada");
                }

                _logger.LogInformation("Busca de sessões realizada com sucesso");
                return Ok(sessions);

            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar sessões");
                throw new Exception($"Erro ao buscar sessões: {e.Message}");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<SessionDto>> CreateSessionAsync(SessionDto sessionDto)
        {
            try
            {
                _logger.LogInformation("Criando sessão");
                SessionDto session = await _sessionService.CreateSession(sessionDto);

                if (session == null)
                {
                    _logger.LogError("Erro ao criar sessão");
                    return BadRequest("Message: Erro ao criar sessão");
                }

                _logger.LogInformation("Sessão criada com sucesso");
                return Ok(session);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao criar sessão");
                throw new Exception($"Erro ao criar sessão: {e.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<SessionDto>> UpdateSessionAsync(SessionDto sessionDto)
        {
            try
            {
                _logger.LogInformation("Atualizando sessão");
                await _sessionService.UpdateSession(sessionDto);

                _logger.LogInformation("Sessão atualizada com sucesso");
                return Ok(sessionDto);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao atualizar sessão de Id {sessionDto.Id}");
                throw new Exception($"Erro ao atualizar sessão: {e.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteSessionAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deletando sessão");
                await _sessionService.DeleteSession(id);

                _logger.LogInformation("Sessão deletada com sucesso");
                return Ok($"Message: Sessão {id} deletada com sucesso");
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao deletar sessão de Id {id}");
                throw new Exception($"Erro ao deletar sessão: {e.Message}");
            }
        }
    }
}
