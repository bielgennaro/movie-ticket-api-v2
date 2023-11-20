#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MovieTicket.WebApi.MovieTicket.Application.Dtos;

public class UserDtoLoginRequest
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Please enter a email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Please enter a password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}