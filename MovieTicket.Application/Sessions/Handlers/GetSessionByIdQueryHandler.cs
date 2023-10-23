using MediatR;

using MovieTicket.Application.Sessions.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Sessions.Handlers
{
    public class GetSessionByIdQueryHandler : IRequestHandler<GetSessionByIdQuery, Session>
    {
        private readonly ISessionRepository _sessionRepository;

        public GetSessionByIdQueryHandler( ISessionRepository sessionRepository )
        {
            this._sessionRepository = sessionRepository;
        }

        public async Task<Session> Handle( GetSessionByIdQuery request, CancellationToken cancellationToken )
        {
            return await this._sessionRepository.GetSessionByIdAsync( request.Id ) ?? throw new ApplicationException( "Session not found" );
        }
    }
}
