#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MovieTicket.WebApi.Models;

public class Register
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Please enter a email")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}