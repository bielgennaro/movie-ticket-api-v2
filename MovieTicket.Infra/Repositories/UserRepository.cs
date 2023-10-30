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

    public UserRepository( ApplicationDbContext userContext )
    {
        this._userContext = userContext;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        return await this._userContext.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync( int id )
    {
        return await this._userContext.Users.FindAsync( id );
    }

    public async Task<User> GetUserByEmailAsync( string email )
    {
        return await this._userContext.Users.Where( u => u.Email == email ).FirstOrDefaultAsync();
    }

    public async Task<User> InsertUserAsync( User user )
    {
        this._userContext.Add( user );
        await this._userContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync( User user )
    {
        this._userContext.Update( user );
        await this._userContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> DeleteUserAsync( User user )
    {
        this._userContext.Remove( user );
        await this._userContext.SaveChangesAsync();
        return user;
    }

    //TODO implement this
    public async Task<User> VerifyPasswordAsync( User user, string password, string hashedPassword )
    {
        this._userContext.Users.Where( u => u.Password == password );
        return await this._userContext.Users.FindAsync( user );
    }

    //TODO implement this
    public async Task<string> HashPasswordAsync( string password )
    {
        throw new NotImplementedException();
    }
}