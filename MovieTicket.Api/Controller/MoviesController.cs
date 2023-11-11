#region

using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

#endregion

namespace MovieTicket.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
    {
        var movies = await _movieService.GetMovies();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetMovieById(int id)
    {
        var movie = await _movieService.GetById(id);

        if (movie == null) return NotFound();

        return Ok(movie);
    }

    [HttpPost("create")]
    public async Task<ActionResult<MovieDto>> CreateMovie([FromBody] MovieDto movieDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        await _movieService.Create(movieDto);
        return Ok();
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateMovie([FromBody] MovieDto movieDto)
    {
        if (movieDto == null)
            return BadRequest();

        await _movieService.Update(movieDto);

        return Ok(movieDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        await _movieService.Remove(id);
        return NoContent();
    }
}