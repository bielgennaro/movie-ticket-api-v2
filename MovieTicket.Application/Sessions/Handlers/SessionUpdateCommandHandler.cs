#region

using MediatR;

using MovieTicket.Application.Sessions.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Sessions.Handlers;

public class SessionUpdateCommandHandler : IRequestHandler<SessionUpdateCommand, Session>
{
    private readonly ISessionRepository _sessionRepository;

    public SessionUpdateCommandHandler( ISessionRepository sessionRepository )
    {
        this._sessionRepository = sessionRepository;
    }

    public async Task<Session> Handle( SessionUpdateCommand request, CancellationToken cancellationToken )
    {
        var session = await this._sessionRepository.GetSessionByIdAsync( request.Id ) ??
                      throw new ApplicationException( "Session not found" );

        session.Update( request.Room, request.AvailableTickets, request.Date, request.Price, request.MovieId );

        return await this._sessionRepository.UpdateSessionAsync( session );
    }
}