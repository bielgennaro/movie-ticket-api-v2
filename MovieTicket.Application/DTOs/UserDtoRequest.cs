using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DTOs
{
    public class UserDtoRequest
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter a email")]
        [MinLength(3)]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [MinLength(8)]
        [MaxLength(16)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required] public bool IsAdmin { get; set; }
    }
}