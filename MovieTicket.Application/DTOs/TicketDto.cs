using System.ComponentModel.DataAnnotations;

using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Please enter a session id" )]
        [Display( Name = "Session Id" )]
        public int SessionId { get; private set; }
        public Session? Session { get; private set; }

        [Required( ErrorMessage = "Please enter a user id" )]
        [Display( Name = "User Id" )]
        public int UserId { get; private set; }
        public User? User { get; private set; }
    }
}
