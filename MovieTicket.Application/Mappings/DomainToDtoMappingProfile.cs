#region

using AutoMapper;
using MovieTicket.Application.DTOs;
using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.Mappings;

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
    }
}