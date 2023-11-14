using System.ComponentModel.DataAnnotations;

namespace MovieTicket.WebApi.MovieTicket.Application.Dtos
{
    public class SessionDtoRequest
    {
        [Required(ErrorMessage = "Please enter a room")]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Room")]
        public required string Room { get; set; }

        [Required(ErrorMessage = "Please enter a available tickets")]
        [Display(Name = "Available Tickets")]
        public int AvailableTickets { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; }

        [Required(ErrorMessage = "Please enter a price")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a movie id")]
        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }
    }
}