#region

using MediatR;

using MovieTicket.Application.Sessions.Queries;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

#endregion

namespace MovieTicket.Application.Sessions.Handlers;

public class GetSessionsQueryHandler : IRequestHandler<GetSessionsQuery, IEnumerable<Session>>
{
    private readonly ISessionRepository _sessionRepository;

    public GetSessionsQueryHandler(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<IEnumerable<Session>> Handle(GetSessionsQuery request, CancellationToken cancellationToken)
    {
        return await _sessionRepository.GetSessionsAsync();
    }
}