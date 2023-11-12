#region

using AutoMapper;
using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Services
{
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
            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        public async Task<TicketDto> GetTicketById(int id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id);
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<TicketDto> CreateTicket(TicketDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            var newTicket = await _ticketRepository.InsertTicketAsync(ticket);
            return _mapper.Map<TicketDto>(newTicket);
        }

        public async Task UpdateTicket(TicketDto ticketDto, int id)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            await _ticketRepository.UpdateTicketAsync(ticket, id);
        }

        public async Task DeleteTicket(int id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id);
            if (ticket != null) await _ticketRepository.DeleteTicketAsync(ticket);
        }
    }
}