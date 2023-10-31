using AutoMapper;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Movies.Commands;
using MovieTicket.Application.Sessions.Commands;
using MovieTicket.Application.Tickets.Commands;
using MovieTicket.Application.Users.Commands;

namespace MovieTicket.Application.Mappings
{
    public class DtoToCommandMappingProfile : Profile
    {
        public DtoToCommandMappingProfile()
        {
            this.CreateMap<SessionDto, SessionCreateCommand>();

            this.CreateMap<TicketDto, TicketCreateCommand>();

            this.CreateMap<UserDto, UserCreateCommand>();

            this.CreateMap<MovieDto, MovieCreateCommand>();
        }
    }
}
