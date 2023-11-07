#region

using MediatR;

using MovieTicket.Application.Sessions.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Sessions.Handlers;

public class SessionRemoveCommandHandler : IRequestHandler<SessionRemoveCommand, Session>
{
    private readonly ISessionRepository _sessionRepository;

    public SessionRemoveCommandHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<Session> Handle(SessionRemoveCommand request, CancellationToken cancellationToken)
    {
        var session = await _sessionRepository.GetSessionByIdAsync(request.Id) ??
                      throw new ApplicationException("Error removing session");

        await _sessionRepository.DeleteSessionAsync(session);
        return session;
    }
}