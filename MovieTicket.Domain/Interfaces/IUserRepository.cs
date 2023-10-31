#region

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();

    Task<User> GetUserByIdAsync( int id );

    Task<User> GetUserByEmailAsync( string email );

    Task<User> InsertUserAsync( User user );

    Task<User> UpdateUserAsync( User user );

    Task<User> DeleteUserAsync( User user );
}