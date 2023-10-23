﻿using MediatR;

using MovieTicket.Application.Tickets.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Tickets.Handlers
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Ticket>
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketByIdQueryHandler( ITicketRepository ticketRepository )
        {
            this._ticketRepository = ticketRepository;
        }

        public async Task<Ticket> Handle( GetTicketByIdQuery request, CancellationToken cancellationToken )
        {
            return await this._ticketRepository.GetTicketByIdAsync( request.Id ) ?? throw new ApplicationException( "Ticket not found" );
        }
    }
}
