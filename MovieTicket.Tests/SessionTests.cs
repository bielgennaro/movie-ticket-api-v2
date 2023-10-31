#region

using FluentAssertions;

using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Validation;

#endregion

namespace MovieTicket.Domain.Tests;

// TODO: Add tests for Session
public class SessionTests
{
    [Fact( DisplayName = "Criar sessão com sala inválida" )]
    public void CreateSession_WithInvalidRoom()
    {
        Action action = () => new Session( "", 1, DateTime.Now, 10.00m, 1 );
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage( "Invalid room. Room is required" );
    }

    [Fact( DisplayName = "Criar sessão com sala muito longa" )]
    public void CreateSession_WithInvalidStringRoom()
    {
        Action action = () => new Session( "2B2", 1, DateTime.Now, 10.00m, 1 );
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage( "Invalid room. Too long, maximum 2 characters" );
    }

    [Fact( DisplayName = "Criar sessão com sala muito curta" )]
    public void CreateSession_WithInvalidShortStringRoom()
    {
        Action action = () => new Session( "2", 1, DateTime.Now, 10.00m, 1 );
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage( "Invalid room. Too short, minimum 2 characters" );
    }

    [Fact( DisplayName = "Criar sessão com filme inválido" )]
    public void CreateSession_WithInvalidMovie()
    {
        Action action = () => new Session( "2B", 10, DateTime.Now, 10.00m, -1 );
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage( "Invalid movie id. Movie id is required" );
    }

    [Fact( DisplayName = "Criar sessão com preço inválido" )]
    public void CreateSession_WithInvalidPrice()
    {
        Action action = () => new Session( 1, "2B", 1, DateTime.Now, -1.00m, 1 );
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage( "Invalid price. Price must be greater than or equal to zero" );
    }

    [Fact( DisplayName = "Criar sessão com id inválido" )]
    public void CreateSession_WithInvalidId()
    {
        Action action = () => new Session( 0, "2B", 1, DateTime.Now, 10.00m, 1 );
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage( "Invalid Id value" );
    }
}