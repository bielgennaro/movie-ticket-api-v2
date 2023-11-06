#region

using FluentAssertions;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Validation;

#endregion

namespace MovieTicket.Domain.Tests;

public class MovieTests
{
    [Fact(DisplayName = "Adicionar filme com genêro inválido")]
    public void AddMovie_WithInvalidGender()
    {
        Action action = () => new Movie("", "teste sinopse", "teste titulo", "teste diretor", "teste banner");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid gender. Gender is required");
    }

    [Fact(DisplayName = "Adicionar filme com sinopse inválida")]
    public void AddMovie_WithInvalidSynopsis()
    {
        Action action = () => new Movie("teste genero", "", "teste titulo", "teste diretor", "teste banner");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid synopsis. Synopsis is required");
    }

    [Fact(DisplayName = "Adicionar filme com título inválido")]
    public void AddMovie_WithInvalidTitle()
    {
        Action action = () => new Movie("teste genero", "teste sinopse", "", "teste diretor", "teste banner");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid title. Title is required");
    }

    [Fact(DisplayName = "Adicionar filme com diretor inválido")]
    public void AddMovie_WithInvalidDirector()
    {
        Action action = () => new Movie("teste genero", "teste sinopse", "teste titulo", "", "teste banner");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid director. Director is required");
    }

    [Fact(DisplayName = "Adicionar filme com url do banner inválida")]
    public void AddMovie_WithInvalidBannerUrl()
    {
        Action action = () => new Movie("teste genero", "teste sinopse", "teste titulo", "teste diretor", "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid banner url. Banner url is required");
    }

    [Fact(DisplayName = "Adicionar filme com url do banner muito grande")]
    public void AddMovie_WithLongBannerUrl()
    {
        Action action = () => new Movie("teste genero", "teste sinopse", "teste titulo", "teste diretor",
            "teste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banneteste banner teste banner teste banne");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid banner url. Too long, maximum 255 characters");
    }
}