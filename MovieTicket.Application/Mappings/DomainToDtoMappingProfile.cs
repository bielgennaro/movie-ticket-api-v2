using AutoMapper;

using MovieTicket.Application.DTOs;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            this.CreateMap<Session, SessionDto>()
                .ReverseMap();

            this.CreateMap<Ticket, TicketDto>()
                .ReverseMap();

            this.CreateMap<User, UserDto>()
                .ReverseMap();

            this.CreateMap<Movie, MovieDto>()
                .ReverseMap();
        }
    }
}
