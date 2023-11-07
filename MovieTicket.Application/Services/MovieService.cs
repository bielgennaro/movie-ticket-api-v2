#region

using AutoMapper;

using MediatR;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Application.Movies.Commands;
using MovieTicket.Application.Movies.Queries;

#endregion

namespace MovieTicket.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public MovieService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDto>> GetMovies()
    {
        GetMoviesQuery moviesQuery = new GetMoviesQuery();

        IEnumerable<Domain.Entities.Movie> result = await _mediator.Send(moviesQuery);

        return _mapper.Map<IEnumerable<MovieDto>>(result);
    }

    public async Task<MovieDto> GetMovieById(int id)
    {
        GetMovieByIdQuery movieQuery = new GetMovieByIdQuery(id);

        Domain.Entities.Movie result = await _mediator.Send(movieQuery) ?? throw new ApplicationException("Movie not found");

        return _mapper.Map<MovieDto>(result);
    }

    public async Task<MovieDto> CreateMovie(MovieDto movieDto)
    {
        MovieCreateCommand movieCommand = _mapper.Map<MovieCreateCommand>(movieDto);

        Domain.Entities.Movie result = await _mediator.Send(movieCommand);

        return _mapper.Map<MovieDto>(result);
    }

    public async Task UpdateMovie(MovieDto movieDto)
    {
        MovieUpdateCommand movieCommand = _mapper.Map<MovieUpdateCommand>(movieDto);
        await _mediator.Send(movieCommand);
    }

    public async Task DeleteMovie(int id)
    {
        MovieRemoveCommand movieCommand = new MovieRemoveCommand(id);
        Domain.Entities.Movie result = await _mediator.Send(movieCommand);
    }
}