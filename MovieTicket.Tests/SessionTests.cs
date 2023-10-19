using FluentAssertions;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Domain.Tests
{
    // TODO: Add tests for Session
    public class SessionTests
    {
        [Fact( DisplayName = "Criar sessão com sala inválida" )]
        public void CreateSession_WithInvalidRoom()
        {
            Action action = () => new Session( "", 1, DateTime.Now, 10.00m, 1 );
            action.Should()
                .Throw<MovieTicket.Domain.Validation.DomainExceptionValidation>()
                .WithMessage( "Invalid room. Room is required" );
        }

        [Fact( DisplayName = "Criar sessão com sala muito longa" )]
        public void CreateSession_WithInvalidStringRoom()
        {
            Action action = () => new Session( "2B2", 1, DateTime.Now, 10.00m, 1 );
            action.Should()
                .Throw<MovieTicket.Domain.Validation.DomainExceptionValidation>()
                .WithMessage( "Invalid room. Too short, maximum 2 characters" );
        }

        [Fact( DisplayName = "Criar sessão com sala muito curta" )]
        public void CreateSession_WithInvalidShortStringRoom()
        {
            Action action = () => new Session( "2", 1, DateTime.Now, 10.00m, 1 );
            action.Should()
                .Throw<MovieTicket.Domain.Validation.DomainExceptionValidation>()
                .WithMessage( "Invalid room. Too short, minimum 2 characters" );
        }
    }
}
