#region

using Microsoft.AspNetCore.Identity;
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
        private readonly PasswordHasher<User> _passwordHashService;

        public UserRepository(ApplicationDbContext dbContext, PasswordHasher<User> passwordHashService)
        {
            _dbContext = dbContext;
            _passwordHashService = passwordHashService;
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
            _dbContext.Users.Add(user);
            var hashedPassword = _passwordHashService.HashPassword(user, user.Password);
            await _dbContext.SaveChangesAsync();
            return user;
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