#region

using AutoMapper;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Movies.Commands;
using MovieTicket.Application.Sessions.Commands;
using MovieTicket.Application.Tickets.Commands;
using MovieTicket.Application.Users.Commands;

#endregion

namespace MovieTicket.Application.Mappings;

public class DtoToCommandMappingProfile : Profile
{
    public DtoToCommandMappingProfile()
    {
        CreateMap<SessionDto, SessionCreateCommand>();

        CreateMap<TicketDto, TicketCreateCommand>();

        CreateMap<UserDto, UserCreateCommand>();

        CreateMap<MovieDto, MovieCreateCommand>();
    }
}