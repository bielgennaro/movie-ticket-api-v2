#region

using AutoMapper;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMapper _mapper;
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDto>> GetMovies()
    {
        var movies = await _movieRepository.GetMoviesAsync();
        var moviesDto = _mapper.Map<IEnumerable<MovieDto>>(movies);
        return moviesDto;
    }

    public async Task<MovieDto> GetMovieById(int id)
    {
        var movie = await _movieRepository.GetMovieByIdAsync(id);
        var movieDto = _mapper.Map<MovieDto>(movie);
        return movieDto;
    }

    public async Task<MovieDto> CreateMovie(MovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        var newMovie = await _movieRepository.InsertMovieAsync(movie);
        var newMovieDto = _mapper.Map<MovieDto>(newMovie);
        return newMovieDto;
    }

    public async Task UpdateMovie(MovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        await _movieRepository.UpdateMovieAsync(movie);
    }

    public async Task DeleteMovie(int id)
    {
        var movie = _movieRepository.GetMovieByIdAsync(id).Result;
        await _movieRepository.DeleteMovieAsync(movie);
    }
}