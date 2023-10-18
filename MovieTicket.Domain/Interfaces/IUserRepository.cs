using MovieTicket.Domain.Entities;

namespace MovieTicket.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>>GetusersAsync();
    
    Task<User>GetUserByIdAsync( int id );
    
    Task<User>GetUserByEmailAsync( string email );
    
    Task<User>InsertUserAsync( User user );
    
    Task<User>UpdateUserAsync( User user );
    
    Task<bool>DeleteUserAsync( int id );

    Task<bool> VerifyPasswordAsync(string password, string hashedPassword);
    
    Task<string> HashPasswordAsync(string password);
}