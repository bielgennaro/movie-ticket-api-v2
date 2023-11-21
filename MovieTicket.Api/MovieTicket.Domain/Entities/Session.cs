#region

using MovieTicket.Domain.Validation;

using System.ComponentModel.DataAnnotations;

#endregion

namespace MovieTicket.Domain.Entities
{
    public class Session
    {
        public Session(int availableTickets, DateTime date, int movieId)
        {
            ValidateDomain(availableTickets, movieId);
            Date = date;
        }

        public Session(int id, int availableTickets, DateTime date, int movieId)
        {
            ValidateDomain(availableTickets, movieId);
            Date = date;
            DomainExceptionValidation.When(id <= 0, "Invalid Id value");
            Id = id;
            MovieId = movieId;
        }

        public int Id { get; set; }

        [Display(Name = "Available Tickets")]
        public int AvailableTickets { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Time)]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Display(Name = "Movie Id")]
        public int MovieId { get; set; }
        public Movie Movie { get; }

        private void ValidateDomain(int availableTickets, int movieId)
        {
            DomainExceptionValidation.When(availableTickets < 0,
                "Invalid available tickets. Available tickets must be greater than or equal to zero");

            DomainExceptionValidation.When(movieId < 0,
                "Invalid movie id. Movie id is required");

            MovieId = movieId;
            AvailableTickets = availableTickets;
        }
    }
}