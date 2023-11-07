#region

using MovieTicket.Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#endregion

namespace MovieTicket.Application.DTOs;

public class TicketDto
{
    [JsonIgnore]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a session id")]
    [Display(Name = "Session Id")]
    public int SessionId { get; }

    [JsonIgnore]
    public Session? Session { get; }

    [Required(ErrorMessage = "Please enter a user id")]
    [Display(Name = "User Id")]
    public int UserId { get; }

    [JsonIgnore]
    public User? User { get; }
}