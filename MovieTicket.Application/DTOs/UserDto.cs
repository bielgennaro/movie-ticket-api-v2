using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [DataType( DataType.EmailAddress )]
        [Required( ErrorMessage = "Please enter a email" )]
        [MinLength( 3 )]
        [MaxLength( 100 )]
        [Display( Name = "Email" )]
        public string Email { get; private set; }

        [Required( ErrorMessage = "Please enter a password" )]
        [MinLength( 8 )]
        [MaxLength( 16 )]
        [DataType( DataType.Password )]
        [Display( Name = "Password" )]
        public string Password { get; private set; }

        [Required]
        [Display( Name = "Is Admin" )]
        public bool IsAdmin { get; private set; }
    }
}
