#region

using MovieTicket.Domain.Validation;

#endregion

namespace MovieTicket.Domain.Entities
{
    public class Session
    {
        public Session(string room, int availableTickets, DateTime date, decimal price, int movieId)
        {
            ValidateDomain(room, availableTickets, price, movieId);
            Date = date;
        }

        public Session(int id, string room, int availableTickets, DateTime date, decimal price, int movieId)
        {
            ValidateDomain(room, availableTickets, price, movieId);
            Date = date;
            DomainExceptionValidation.When(id <= 0, "Invalid Id value");
            Id = id;
            MovieId = movieId;
        }

        public int Id { get; set; }
        public string Room { get; set; }
        public int AvailableTickets { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public decimal Price { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; }

        private void ValidateDomain(string room, int availableTickets, decimal price, int movieId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(room),
                "Invalid room. Room is required");

            DomainExceptionValidation.When(availableTickets < 0,
                "Invalid available tickets. Available tickets must be greater than or equal to zero");

            DomainExceptionValidation.When(price < 0,
                "Invalid price. Price must be greater than or equal to zero");

            DomainExceptionValidation.When(movieId < 0,
                "Invalid movie id. Movie id is required");

            MovieId = movieId;
            AvailableTickets = availableTickets;
            Price = price;
            Room = room;
        }
    }
}