using AutoMapper;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService( ITicketRepository ticketRepository, IMapper mapper )
        {
            this._ticketRepository = ticketRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
        {
            var tickets = await this._ticketRepository.GetTicketsAsync();
            var ticketsDto = this._mapper.Map<IEnumerable<TicketDto>>( tickets );
            return ticketsDto;
        }

        public async Task<TicketDto> GetTicketByIdAsync( int id )
        {
            var ticket = await this._ticketRepository.GetTicketByIdAsync( id );
            var ticketDto = this._mapper.Map<TicketDto>( ticket );
            return ticketDto;
        }

        public async Task<TicketDto> CreateTicketAsync( TicketDto ticketDto )
        {
            var ticket = this._mapper.Map<Ticket>( ticketDto );
            var newTicket = await this._ticketRepository.InsertTicketAsync( ticket );
            var newTicketDto = this._mapper.Map<TicketDto>( newTicket );
            return newTicketDto;
        }

        public async Task UpdateTicketAsync( TicketDto ticketDto )
        {
            var ticket = this._mapper.Map<Ticket>( ticketDto );
            await this._ticketRepository.UpdateTicketAsync( ticket );
        }

        public async Task DeleteTicketAsync( int id )
        {
            var ticket = this._ticketRepository.GetTicketByIdAsync( id ).Result;
            await this._ticketRepository.DeleteTicketAsync( ticket );
        }
    }
}
