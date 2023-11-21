#region

using AutoMapper;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Services
{
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
            var moviesEntity = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<IEnumerable<MovieDto>>(moviesEntity);
        }

        public async Task<MovieDto> GetById(int id)
        {
            var movieEntity = await _movieRepository.GetByIdAsync(id);
            return _mapper.Map<MovieDto>(movieEntity);
        }

        public async Task Create(MovieDtoRequest movieDto)
        {
            var movieEntity = _mapper.Map<Movie>(movieDto);
            await _movieRepository.CreateAsync(movieEntity);
        }

        public async Task Update(MovieDtoRequest movieDto, int id)
        {
            var movieEntity = _mapper.Map<Movie>(movieDto);
            await _movieRepository.UpdateAsync(movieEntity, id);
        }

        public async Task Remove(int id)
        {
            var movieEntity = await _movieRepository.GetByIdAsync(id);
            if (movieEntity != null) await _movieRepository.DeleteAsync(movieEntity);
        }
    }
}