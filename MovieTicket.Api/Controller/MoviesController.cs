#region

using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.API.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService, ILogger<MovieController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            try
            {
                var movies = await _movieService.GetMovies();
                _logger.LogInformation("Movies retrieved successfully.");
                return Ok(movies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving movies.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(int id)
        {
            try
            {
                var movie = await _movieService.GetById(id);

                if (movie == null)
                {
                    _logger.LogInformation($"Movie with ID {id} not found.");
                    return NotFound();
                }

                return Ok(movie);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving movie with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<MovieDto>> Create(MovieDtoRequest movieDto)
        {
            try
            {
                await _movieService.Create(movieDto);
                _logger.LogInformation("Movie created successfully.");
                return CreatedAtAction(nameof(GetById), new { Movie = movieDto }, movieDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating movie.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(MovieDtoRequest movieDto, int id)
        {
            try
            {
                await _movieService.Update(movieDto, id);
                _logger.LogInformation($"Movie with ID {id} updated successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating movie with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _movieService.Remove(id);
                _logger.LogInformation($"Movie with ID {id} deleted successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting movie with ID {id}.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}