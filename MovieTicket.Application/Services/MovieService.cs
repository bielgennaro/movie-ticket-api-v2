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
        var categoriesEntity = await _movieRepository.GetMoviesAsync();
        return _mapper.Map<IEnumerable<MovieDto>>(categoriesEntity);
    }

    public async Task<MovieDto> GetById(int id)
    {
        var categoryEntity = await _movieRepository.GetByIdAsync(id);
        return _mapper.Map<MovieDto>(categoryEntity);
    }

    public async Task Create(MovieDto movieDto)
    {
        var categoryEntity = _mapper.Map<Movie>(movieDto);
        await _movieRepository.CreateAsync(categoryEntity);
    }

    public async Task Update(MovieDto movieDto)
    {
        var categoryEntity = _mapper.Map<Movie>(movieDto);
        await _movieRepository.UpdateAsync(categoryEntity);
    }

    public async Task Remove(int id)
    {
        var categoryEntity = _movieRepository.GetByIdAsync(id).Result;
        await _movieRepository.DeleteAsync(categoryEntity);
    }
}