#region

using MovieTicket.Domain.Validation;

using System.Text.Json.Serialization;

#endregion

namespace MovieTicket.Domain.Entities;

public sealed class User : Entity
{
    [JsonConstructor]
    public User(string email, string password, bool isAdmin)
    {
        ValidateDomain(email, password);
        IsAdmin = isAdmin;
    }

    public User(int id, string email, string password, bool isAdmin)
    {
        ValidateDomain(email, password);
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        IsAdmin = isAdmin;
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsAdmin { get; private set; }

    public void Update(string email, string password, bool isAdmin)
    {
        ValidateDomain(email, password);
        IsAdmin = isAdmin;
    }

    public void ValidateDomain(string email, string password)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "Invalid email. Email is required");

        DomainExceptionValidation.When(email.Length < 3,
            "Invalid email. Too short, minimum 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(password),
            "Invalid password. Password is required");

        DomainExceptionValidation.When(password.Length < 8,
            "Invalid password. Too short, minimum 8 characters");

        DomainExceptionValidation.When(password.Length > 16,
            "Invalid password. Too long, maximum 16 characters");

        Email = email;
        Password = password;
    }
}