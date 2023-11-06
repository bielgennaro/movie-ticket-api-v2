#region

using MovieTicket.Domain.Validation;

#endregion

namespace MovieTicket.Domain.Entities;

public sealed class Movie : Entity
{
    public Movie(string gender, string synopsis, string title, string director, string bannerUrl)
    {
        ValidateDomain(gender, synopsis, title, director, bannerUrl);
    }

    public Movie(int id, string gender, string synopsis, string title, string director, string bannerUrl)
    {
        ValidateDomain(gender, synopsis, title, director, bannerUrl);
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
    }

    public string Gender { get; private set; }
    public string Synopsis { get; private set; }
    public string Title { get; private set; }
    public string Director { get; private set; }
    public string BannerUrl { get; private set; }

    public void Update(string gender, string synopsis, string title, string director, string bannerUrl)
    {
        ValidateDomain(gender, synopsis, title, director, bannerUrl);
    }

    private void ValidateDomain(string gender, string synopsis, string title, string director, string bannerUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(gender),
            "Invalid gender. Gender is required");

        DomainExceptionValidation.When(gender.Length < 3,
            "Invalid gender. Too short, minimum 3 characters");

        DomainExceptionValidation.When(gender.Length > 100,
            "Invalid gender. Too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(synopsis),
            "Invalid synopsis. Synopsis is required");

        DomainExceptionValidation.When(synopsis.Length < 3,
            "Invalid synopsis. Too short, minimum 3 characters");

        DomainExceptionValidation.When(synopsis.Length > 100,
            "Invalid synopsis. Too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(title),
            "Invalid title. Title is required");

        DomainExceptionValidation.When(title.Length < 3,
            "Invalid title. Too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(director),
            "Invalid director. Director is required");

        DomainExceptionValidation.When(director.Length < 3,
            "Invalid director. Too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(bannerUrl),
            "Invalid banner url. Banner url is required");

        DomainExceptionValidation.When(bannerUrl.Length > 255,
            "Invalid banner url. Too long, maximum 255 characters");

        Gender = Gender;
        Synopsis = synopsis;
        Title = title;
        Director = director;
        BannerUrl = bannerUrl;
    }
}