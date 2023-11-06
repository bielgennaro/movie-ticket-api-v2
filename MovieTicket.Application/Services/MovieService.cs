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

    public async Task<IEnumerable<MovieDto>> GetMoviesAsync()
    {
        var moviesQuery = new GetMoviesQuery();

        var result = await _mediator.Send(moviesQuery);

        return _mapper.Map<IEnumerable<MovieDto>>(result);
    }

    public async Task<MovieDto> GetMovieByIdAsync(int id)
    {
        var movieQuery = new GetMovieByIdQuery(id);

        var result = await _mediator.Send(movieQuery) ?? throw new ApplicationException("Movie not found");

        return _mapper.Map<MovieDto>(result);
    }

    public async Task<MovieDto> CreateMovieAsync(MovieDto movieDto)
    {
        var movieCommand = _mapper.Map<MovieCreateCommand>(movieDto);

        var result = await _mediator.Send(movieCommand);

        return _mapper.Map<MovieDto>(result);
    }

    public async Task UpdateMovieAsync(MovieDto movieDto)
    {
        var movieCommand = _mapper.Map<MovieUpdateCommand>(movieDto);
        await _mediator.Send(movieCommand);
    }

    public async Task DeleteMovieAsync(int id)
    {
        var movieCommand = new MovieRemoveCommand(id);
        var result = await _mediator.Send(movieCommand);
    }
}