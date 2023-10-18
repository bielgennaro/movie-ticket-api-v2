using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

namespace MovieTicket.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _userContext;

        public UserRepository(ApplicationDbContext userContext)
        {
            this._userContext = userContext;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await this._userContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await this._userContext.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await this._userContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> InsertUserAsync(User user)
        {
            _userContext.Add(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _userContext.Update(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            _userContext.Remove(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        //TODO implement this
        public async Task<bool> VerifyPasswordAsync(string password, string hashedPassword)
        {
            throw new NotImplementedException();
        }

        //TODO implement this
        public async Task<string> HashPasswordAsync(string password)
        {
            throw new NotImplementedException();
        }
    }
}
