#region

using MovieTicket.Domain.Validation;

#endregion

namespace MovieTicket.Domain.Entities;

public class Session : Entity
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

    public string Room { get; private set; }
    public int AvailableTickets { get; private set; }
    public DateTime Date { get; private set; }
    public decimal Price { get; private set; }

    public int MovieId { get; private set; }
    public Movie Movie { get; }

    public void Update(string room, int availableTickets, DateTime date, decimal price, int movieId)
    {
        ValidateDomain(room, availableTickets, price, movieId);
        Date = date;
    }

    private void ValidateDomain(string room, int availableTickets, decimal price, int movieId)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(room),
            "Invalid room. Room is required");

        DomainExceptionValidation.When(room.Length < 2,
            "Invalid room. Too short, minimum 2 characters");

        DomainExceptionValidation.When(room.Length > 2,
            "Invalid room. Too long, maximum 2 characters");

        DomainExceptionValidation.When(availableTickets < 0,
            "Invalid available tickets. Available tickets must be greater than or equal to zero");

        DomainExceptionValidation.When(price < 0,
            "Invalid price. Price must be greater than or equal to zero");

        DomainExceptionValidation.When(movieId < 0,
            "Invalid movie id. Movie id is required");

        MovieId = movieId;
        Room = room;
        AvailableTickets = availableTickets;
        Price = price;
    }
}