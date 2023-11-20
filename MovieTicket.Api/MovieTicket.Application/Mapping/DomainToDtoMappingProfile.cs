#region

using AutoMapper;
using MovieTicket.Application.DTOs;
using MovieTicket.Domain.Entities;
using MovieTicket.WebApi.MovieTicket.Application.Dtos;

#endregion

namespace MovieTicket.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Session, SessionDto>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Ticket, TicketDto>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserDto>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Movie, MovieDto>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Session, SessionDtoRequest>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserDtoRequest>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Ticket, TicketDtoRequest>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Movie, MovieDtoRequest>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UserDtoLoginRequest>()
                .ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}