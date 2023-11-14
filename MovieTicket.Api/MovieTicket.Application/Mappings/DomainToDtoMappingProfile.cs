#region

using AutoMapper;

using MovieTicket.Application.DTOs;
using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Session, SessionDto>()
                .ReverseMap();

            CreateMap<Ticket, TicketDto>()
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<Movie, MovieDto>()
                .ReverseMap();

            CreateMap<Session, SessionDtoRequest>()
                .ReverseMap();

            CreateMap<User, UserDtoRequest>()
                .ReverseMap();

            CreateMap<Ticket, TicketDtoRequest>()
                .ReverseMap();

            CreateMap<Movie, MovieDtoRequest>()
                .ReverseMap();
        }
    }
}