#region

using MovieTicket.Domain.Validation;

using System.Text.Json.Serialization;

#endregion

namespace MovieTicket.Domain.Entities
{
    public sealed class User
    {
        [JsonConstructor]
        public User(string email, string password, bool isAdmin)
        {
            ValidateDomain(email, password);
            IsAdmin = isAdmin;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

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
}