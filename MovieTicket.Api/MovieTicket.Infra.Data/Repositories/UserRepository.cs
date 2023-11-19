#region

using System.Collections.Generic;
using System.Threading.Tasks;

using BCrypt.Net;

using Microsoft.EntityFrameworkCore;

using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

#endregion

namespace MovieTicket.WebApi.MovieTicket.Infra.Data.Repositories
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
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var newUser = new User(user.Email, hashPassword, user.IsAdmin);
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task UpdateUserAsync(User user, int id)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);

            if (existingUser != null)
            {
                existingUser.Email = user.Email;

                if (!string.IsNullOrEmpty(user.Password))
                {
                    existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                }

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
