using AutoMapper;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService( IMovieRepository movieRepository, IMapper mapper )
        {
            this._movieRepository = movieRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesAsync()
        {
            var movies = await this._movieRepository.GetMoviesAsync();
            var moviesDto = this._mapper.Map<IEnumerable<MovieDto>>( movies );
            return moviesDto;
        }

        public async Task<MovieDto> GetMovieByIdAsync( int id )
        {
            var movie = await this._movieRepository.GetMovieByIdAsync( id );
            var movieDto = this._mapper.Map<MovieDto>( movie );
            return movieDto;
        }

        public async Task<MovieDto> CreateMovieAsync( MovieDto movieDto )
        {
            var movie = this._mapper.Map<Movie>( movieDto );
            var newMovie = await this._movieRepository.InsertMovieAsync( movie );
            var newMovieDto = this._mapper.Map<MovieDto>( newMovie );
            return newMovieDto;
        }

        public async Task UpdateMovieAsync( MovieDto movieDto )
        {
            var movie = this._mapper.Map<Movie>( movieDto );
            await this._movieRepository.UpdateMovieAsync( movie );
        }

        public async Task DeleteMovieAsync( int id )
        {
            var movie = this._movieRepository.GetMovieByIdAsync( id ).Result;
            await this._movieRepository.DeleteMovieAsync( movie );
        }
    }
}
