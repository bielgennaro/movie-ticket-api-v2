#region

using AutoMapper;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Services;

public class TicketService : ITicketService
{
    private readonly IMapper _mapper;
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TicketDto>> GetTickets()
    {
        var tickets = await _ticketRepository.GetTicketsAsync();
        var ticketsDto = _mapper.Map<IEnumerable<TicketDto>>(tickets);
        return ticketsDto;
    }

    public async Task<TicketDto> GetTicketById(int id)
    {
        var ticket = await _ticketRepository.GetTicketByIdAsync(id);
        var ticketDto = _mapper.Map<TicketDto>(ticket);
        return ticketDto;
    }

    public async Task<TicketDto> CreateTicket(TicketDto ticketDto)
    {
        var ticket = _mapper.Map<Ticket>(ticketDto);
        var newTicket = await _ticketRepository.InsertTicketAsync(ticket);
        var newTicketDto = _mapper.Map<TicketDto>(newTicket);
        return newTicketDto;
    }

    public async Task UpdateTicket(TicketDto ticketDto)
    {
        var ticket = _mapper.Map<Ticket>(ticketDto);
        await _ticketRepository.UpdateTicketAsync(ticket);
    }

    public async Task DeleteTicket(int id)
    {
        var ticket = _ticketRepository.GetTicketByIdAsync(id).Result;
        await _ticketRepository.DeleteTicketAsync(ticket);
    }
}