#region

using System.ComponentModel.DataAnnotations;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.DTOs;

public class TicketDto
{
    public int Id { get; set; }

    [Required( ErrorMessage = "Please enter a session id" )]
    [Display( Name = "Session Id" )]
    public int SessionId { get; }

    public Session? Session { get; }

    [Required( ErrorMessage = "Please enter a user id" )]
    [Display( Name = "User Id" )]
    public int UserId { get; }

    public User? User { get; }
}