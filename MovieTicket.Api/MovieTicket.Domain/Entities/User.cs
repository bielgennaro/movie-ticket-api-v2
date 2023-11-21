#region

using MovieTicket.Domain.Validation;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public User()
        {
        }

        public int Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        [NotMapped]
        public string? PasswordHash { get; set; }

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

            Email = email;
            Password = password;
        }
    }
}