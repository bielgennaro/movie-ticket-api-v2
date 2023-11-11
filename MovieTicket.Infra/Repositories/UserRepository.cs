#region

using Microsoft.EntityFrameworkCore;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Interfaces;
using MovieTicket.Infra.Data.Context;

#endregion

namespace MovieTicket.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _userContext;

    public UserRepository(ApplicationDbContext userContext)
    {
        _userContext = userContext;
    }

    public async Task<IList<User>> GetUsersAsync()
    {
        return await _userContext.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _userContext.Users.FindAsync(id);
    }

    public async Task<User> InsertUserAsync(User user)
    {
        _userContext.Add(user);
        await _userContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _userContext.Users.Update(user);
        await _userContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteUserAsync(User user)
    {
        _userContext.Remove(user);
        await _userContext.SaveChangesAsync();
        return user;
    }
}