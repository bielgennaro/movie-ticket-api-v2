#region

using MovieTicket.Domain.Entities;

#endregion

namespace MovieTicket.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IList<User>> GetUsersAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> InsertUserAsync(User user);

        Task UpdateUserAsync(User user, int id);

        Task<User> DeleteUserAsync(User user);
    }
}