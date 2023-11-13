#region

using Microsoft.EntityFrameworkCore;

using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

#endregion

namespace MovieTicket.Infra.DataApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User> InsertUserAsync(User user)
        {
            var newUser = new User(user.Email, user.Password, user.IsAdmin);
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task UpdateUserAsync(User user, int id)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);

            if (existingUser != null)
            {
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}