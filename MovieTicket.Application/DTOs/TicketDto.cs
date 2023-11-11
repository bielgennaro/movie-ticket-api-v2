#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MovieTicket.Application.DTOs;

public class TicketDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a session id")]
    [Display(Name = "Session Id")]
    public int SessionId { get; set; }

    [Required(ErrorMessage = "Please enter a user id")]
    [Display(Name = "User Id")]
    public int UserId { get; set; }
}