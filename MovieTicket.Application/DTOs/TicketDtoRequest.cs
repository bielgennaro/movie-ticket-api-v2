using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DTOs
{
    public class TicketDtoRequest
    {
        [Required(ErrorMessage = "Please enter a session id")]
        [Display(Name = "Session Id")]
        public int SessionId { get; set; }

        [Required(ErrorMessage = "Please enter a user id")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }
    }
}