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
        var movie = await _movieService.GetMovieById(id);

        if (movie == null) return NotFound();

        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> CreateMovie([FromBody] MovieDto movieDto)
    {
        var newMovie = await _movieService.CreateMovie(movieDto);
        return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Gender }, newMovie);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] MovieDto movieDto)
    {
        await _movieService.UpdateMovie(movieDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        await _movieService.DeleteMovie(id);
        return NoContent();
    }
}