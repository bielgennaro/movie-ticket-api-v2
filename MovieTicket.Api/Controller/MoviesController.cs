﻿using Microsoft.AspNetCore.Mvc;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;

namespace MovieTicket.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(IMovieService movieService, ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet("getAllMovies", Order = 1)]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesAsync()
        {
            try
            {
                var movies = await _movieService.GetMovies();

                if (movies == null)
                {
                    return NotFound("Message: Nenhum filme encontrado");
                }

                _logger.LogInformation("Busca de filmes realizada com sucesso");
                return Ok(movies);

            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar filmes");
                throw new Exception($"Erro ao buscar filmes: {e.Message}");
            }
        }


        [HttpGet("getMovieById/{id}", Order = 2)]
        public async Task<ActionResult<MovieDto>> GetMovieByIdAsync(int id)
        {
            try
            {
                var movies = await _movieService.GetMovieById(id);

                if (movies == null)
                {
                    return NotFound("Message: Nenhum usuário encontrado");
                }

                _logger.LogInformation("Busca de filmes realizada com sucesso");
                return Ok(movies);

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao buscar filmes");
                throw new Exception($"Erro ao buscar usuário: {e.Message}");
            }
        }

        [HttpPost("createMovie", Order = 3)]
        public async Task<ActionResult<MovieDto>> CreateMovieAsync([FromBody] MovieDto movieDto)
        {
            try
            {
                if (movieDto == null)
                {
                    _logger.LogError("Erro ao criar filme: Dados inválidos");
                    return BadRequest("Message: Dados inválidos");
                }

                await _movieService.CreateMovie(movieDto);

                _logger.LogInformation("Filme criado com sucesso");
                return Ok(movieDto);
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao criar filme");
                throw new Exception($"Erro ao criar filme: {e.Message}");
            }
        }

        [HttpPut("updateMovie/{id}", Order = 4)]
        public async Task<ActionResult> UpdateMovieAsync(int id, [FromBody] MovieDto movieDto)
        {
            try
            {
                var movie = await _movieService.GetMovieById(id);

                if (movie == null)
                {
                    return NotFound("Message: Nenhum filme encontrado");
                }

                await _movieService.UpdateMovie(movieDto);

                _logger.LogInformation("Filme atualizado com sucesso");
                return Ok($"Message: Filme {id} atualizado com sucesso");
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao atualizar filme");
                throw new Exception($"Erro ao atualizar filme: {e.Message}");
            };
        }

        [HttpDelete("deleteMovie/{id}", Order = 5)]
        public async Task<ActionResult> DeleteMovieAsync(int id)
        {
            try
            {
                var movie = await _movieService.GetMovieById(id);

                if (movie == null)
                {
                    return NotFound("Message: Nenhum filme encontrado");
                }

                await _movieService.DeleteMovie(id);

                _logger.LogInformation("Filme deletado com sucesso");
                return Ok($"Message: Filme {id} deletado com sucesso");
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao deletar filme");
                throw new Exception($"Erro ao deletar filme: {e.Message}");
            };
        }
    }
}