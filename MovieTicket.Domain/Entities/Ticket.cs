namespace MovieTicket.Domain.Entities;

public class Ticket : Entity
{
    public Ticket( int sessionId, int userId )
    {
        this.SessionId = sessionId;
        this.UserId = userId;
    }

    public int SessionId { get; private set; }
    public Session? Session { get; }

    public int UserId { get; private set; }
    public User? User { get; }

    public void Update( int sessionId, int userId )
    {
        this.SessionId = sessionId;
        this.UserId = userId;
    }
}