using MovieTicket.Domain.Validation;

namespace MovieTicket.Domain.Entities;

public class Session : Entity
{
    public string Room { get; private set; }
    public int AvailableTickets { get; private set; }
    public DateTime Date { get; private set; }
    public decimal Price { get; private set; }
    
    public int MovieId { get; private set; }
    public Movie Movie { get; private set; }
    
    public Session( string room, int availableTickets, DateTime date, decimal price, int movieId )
    {
        this.ValidateDomain( room, availableTickets, date, price );
        this.MovieId = movieId;
    }
    
    public Session( int id, string room, int availableTickets, DateTime date, decimal price, int movieId )
    {
        this.ValidateDomain( room, availableTickets, date, price );
        DomainExceptionValidation.When( id < 0, "Invalid Id value" );
        this.Id = id;
        this.MovieId = movieId;
    }
    
    private void ValidateDomain( string room, int availableTickets, DateTime date, decimal price )
    {
        DomainExceptionValidation.When( string.IsNullOrEmpty( room ),
            "Invalid room. Room is required" );

        DomainExceptionValidation.When( room.Length < 10,
            "Invalid room. Too short, minimum 10 characters" );
        
        DomainExceptionValidation.When( availableTickets < 0,
            "Invalid available tickets. Available tickets must be greater than or equal to zero" );
        
        DomainExceptionValidation.When( date == null,
            "Invalid date. Date is required" );
        
        DomainExceptionValidation.When( price < 0,
            "Invalid price. Price must be greater than or equal to zero" );
        
        this.Room = room;
        this.AvailableTickets = availableTickets;
        this.Date = date;
        this.Price = price;
    }
}