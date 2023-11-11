#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MovieTicket.Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    
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

    [Required] 
    public bool IsAdmin { get; set; }
}