#region

using MovieTicket.Domain.Entities;

using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;

#endregion

namespace MovieTicket.WebApi.MovieTicket.Application.Dtos
{
    public class SessionDtoRequest
    {

        [Required(ErrorMessage = "Please enter a available tickets")]
        [Display(Name = "Available Tickets")]
        public int AvailableTickets { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a movie id")]
        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }
    }
}