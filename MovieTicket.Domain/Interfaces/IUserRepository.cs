using MovieTicket.Domain.Entities;

namespace MovieTicket.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();

    Task<User> GetUserByIdAsync( int id );

    Task<User> GetUserByEmailAsync( string email );

    Task<User> InsertUserAsync( User user );

    Task<User> UpdateUserAsync( User user );

    Task<User> DeleteUserAsync( User user );

    //TODO implement this
    Task<bool> VerifyPasswordAsync( string password, string hashedPassword );

    //TODO implement this
    Task<string> HashPasswordAsync( string password );
}