#region

using MediatR;
using MovieTicket.Application.Sessions.Commands;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Sessions.Handlers;

public class SessionCreateCommandHandler : IRequestHandler<SessionCreateCommand, Session>
{
    private readonly ISessionRepository _sessionRepository;

    public SessionCreateCommandHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<Session> Handle(SessionCreateCommand request, CancellationToken cancellationToken)
    {
        var session = new Session(request.Room, request.AvailableTickets, request.Date, request.Price,
            request.MovieId);

        return session == null
            ? throw new ApplicationException("There was an error creating the session")
            : await _sessionRepository.InsertSessionAsync(session);
    }
}