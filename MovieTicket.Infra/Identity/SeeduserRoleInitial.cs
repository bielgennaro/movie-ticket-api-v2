using Microsoft.AspNetCore.Identity;

using MovieTicket.Domain.Account;

namespace MovieTicket.Infra.Data.Identity;

public class SeeduserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeeduserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedUsers()
    {
        if(_userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            ApplicationUser user = new ApplicationUser();

            user.Email = "usuario@localhost";
            user.UserName = "usuario@localhost";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "BestSecPassword").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "User").Wait();
            }
        }

        if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
        {
            ApplicationUser admin = new ApplicationUser();

            admin.Email = "admin@localhost";
            admin.UserName = "admin@localhost";
            admin.NormalizedEmail = "ADMIN@LOCALHOST";
            admin.NormalizedUserName = "ADMIN@LOCALHOST";
            admin.EmailConfirmed = true;
            admin.LockoutEnabled = false;
            admin.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(admin, "BestSecPassword").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(admin, "Admin").Wait();
            }
        }
    }

    public void SeedRoles()
    {
        if (!_roleManager.RoleExistsAsync("User").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "User";
            role.NormalizedName = "USER";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }

        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }
}