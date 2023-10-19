using FluentAssertions;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Domain.Tests
{
    public class UserTests
    {
        [Fact( DisplayName = "Criar usuário com email nulo" )]
        public void CreateUser_WithNullEmail()
        {
            Action action = () => new User( null, "teste senha12435251", true );
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage( "Invalid email. Email is required" );
        }

        [Fact( DisplayName = "Criar usuário com email inválido" )]
        public void CreateUser_WithInvalidEmail()
        {
            Action action = () => new User( "te", "testesenha", true );
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage( "Invalid email. Please enter a valid email." );
        }

        [Fact( DisplayName = "Criar usuário com senha muito curta" )]
        public void CreateUser_WithShortPasswordSize()
        {
            Action action = () => new User( "testemail@gmail.com", "tes", true );
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage( "Invalid password. Too short, minimum 8 characters" );
        }

        [Fact( DisplayName = "Criar usuário com senha muito grande" )]
        public void CreateUser_WithLongPasswordSize()
        {
            Action action = () => new User( "testemail@gmail.com", "teste senha9842423424242423424932813312", true );
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage( "Invalid password. Too long, maximum 16 characters" );
        }

        [Fact( DisplayName = "Criar usuário com campo admin false" )]
        public void CreateUser_WithFalseAdminField()
        {
            Action action = () => new User( "testemail@gmail.com", "testesenha", false );
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact( DisplayName = "Criar usuário com campo admin true" )]
        public void CreateUser_WithTrueAdminField()
        {
            Action action = () => new User( "testemail@gmail.com", "teste senha12", true );
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }
    }
}