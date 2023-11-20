#region

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
            var generatedSalt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, generatedSalt);
            user.PasswordHash = hashedPassword;
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> AuthenticateUserAsync(User user)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            return existingUser;
        }


        public async Task UpdateUserAsync(User user, int id)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);

            if (existingUser != null)
            {
                existingUser.Email = user.Email;

                if (!string.IsNullOrEmpty(user.Password))
                    existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

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