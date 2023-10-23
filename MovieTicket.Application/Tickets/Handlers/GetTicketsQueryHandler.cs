﻿using MediatR;

using MovieTicket.Application.Tickets.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Tickets.Handlers
{
    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, IEnumerable<Ticket>>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsQueryHandler( ITicketRepository ticketRepository )
        {
            this._ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> Handle( GetTicketsQuery request, CancellationToken cancellationToken )
        {
            return await this._ticketRepository.GetTicketsAsync();
        }
    }
}
