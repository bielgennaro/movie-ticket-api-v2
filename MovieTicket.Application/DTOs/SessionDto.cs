#region

using System.ComponentModel.DataAnnotations;

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Application.DTOs;

public class SessionDto
{
    public int Id { get; set; }

    [Required( ErrorMessage = "Please enter a room" )]
    [MinLength( 3 )]
    [MaxLength( 100 )]
    [Display( Name = "Room" )]
    public string Room { get; }

    [Required( ErrorMessage = "Please enter a available tickets" )]
    [Display( Name = "Available Tickets" )]
    public int AvailableTickets { get; }

    [Required( ErrorMessage = "Please enter a date" )]
    [Display( Name = "Date" )]
    [DataType( DataType.Date )]
    public DateTime Date { get; }

    [Required( ErrorMessage = "Please enter a price" )]
    [Display( Name = "Price" )]
    [DataType( DataType.Currency )]
    public decimal Price { get; }

    [Required( ErrorMessage = "Please enter a movie id" )]
    [Display( Name = "Movie Id" )]
    public int MovieId { get; }

    public Movie Movie { get; }
}