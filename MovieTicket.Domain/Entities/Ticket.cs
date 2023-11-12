namespace MovieTicket.Domain.Entities;

public class Ticket : Entity
{
    public Ticket(int sessionId, int userId)
    {
        SessionId = sessionId;
        UserId = userId;
    }

    public int SessionId { get; set; }
    public Session? Session { get; }

    public int UserId { get; set; }
    public User? User { get; }
}