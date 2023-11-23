#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace MovieTicket.Application.DTOs
{
    public class SessionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a available tickets")]
        [Display(Name = "Available Tickets")]
        public int AvailableTickets { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [Display(Name = "Date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Please enter a movie id")]
        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }
    }
}