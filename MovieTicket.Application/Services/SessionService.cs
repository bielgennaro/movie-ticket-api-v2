using AutoMapper;

using MovieTicket.Application.DTOs;
using MovieTicket.Application.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;

namespace MovieTicket.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMapper _mapper;

        public SessionService( ISessionRepository sessionRepository, IMapper mapper )
        {
            this._sessionRepository = sessionRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<SessionDto>> GetSessionsAsync()
        {
            var sessions = await this._sessionRepository.GetSessionsAsync();
            var sessionsDto = this._mapper.Map<IEnumerable<SessionDto>>( sessions );
            return sessionsDto;
        }

        public async Task<SessionDto> GetSessionByIdAsync( int id )
        {
            var session = await this._sessionRepository.GetSessionByIdAsync( id );
            var sessionDto = this._mapper.Map<SessionDto>( session );
            return sessionDto;
        }

        public async Task<SessionDto> CreateSessionAsync( SessionDto sessionDto )
        {
            var session = this._mapper.Map<Session>( sessionDto );
            var newSession = await this._sessionRepository.InsertSessionAsync( session );
            var newSessionDto = this._mapper.Map<SessionDto>( newSession );
            return newSessionDto;
        }

        public async Task UpdateSessionAsync( SessionDto sessionDto )
        {
            var session = this._mapper.Map<Session>( sessionDto );
            await this._sessionRepository.UpdateSessionAsync( session );
        }

        public async Task DeleteSessionAsync( int id )
        {
            var session = this._sessionRepository.GetSessionByIdAsync( id ).Result;
            await this._sessionRepository.DeleteSessionAsync( session );
        }
    }
}
