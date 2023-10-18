namespace MovieTicket.Domain.Entities;

public class Ticket : Entity
{
    public int SessionId { get; private set; }
    public Session Session { get; private set; }

    public int UserId { get; private set; }
    public User User { get; private set; }
}