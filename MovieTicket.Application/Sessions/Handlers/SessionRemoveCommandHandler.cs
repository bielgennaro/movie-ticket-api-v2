using MediatR;

using MovieTicket.Application.Sessions.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Sessions.Handlers
{
    public class SessionRemoveCommandHandler : IRequestHandler<SessionRemoveCommand, Session>
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionRemoveCommandHandler( ISessionRepository sessionRepository )
        {
            this._sessionRepository = sessionRepository;
        }

        public async Task<Session> Handle( SessionRemoveCommand request, CancellationToken cancellationToken )
        {
            var session = await this._sessionRepository.GetSessionByIdAsync( request.Id ) ?? throw new ApplicationException( "Error removing session" );

            await this._sessionRepository.DeleteSessionAsync( session );
            return session;
        }
    }
}
