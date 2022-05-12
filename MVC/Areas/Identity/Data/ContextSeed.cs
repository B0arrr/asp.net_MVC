using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC.Areas.Identity.Data;

public class ContextSeed
{
    public static async Task SeedRolesAsync(UserManager<MVCUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Roles
        await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
    }

    public static async Task SeedSuperAdminAsync(UserManager<MVCUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUserSuperAdmin = new MVCUser
        {
            UserName = "superadmin",
            Email = "superadmin@gmail.com",
            FirstName = "superadmin",
            LastName = "superadmin",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUserSuperAdmin.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUserSuperAdmin.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUserSuperAdmin, "SuperAdmin123!");
                await userManager.AddToRoleAsync(defaultUserSuperAdmin, Roles.SuperAdmin.ToString());
            }
        }
    }

    public static async Task SeedAdminAsync(UserManager<MVCUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        var defaultUserAdmin = new MVCUser
        {
            UserName = "admin",
            Email = "admin@gmail.com",
            FirstName = "admin",
            LastName = "admin",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUserAdmin.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUserAdmin.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUserAdmin, "Admin123!");
                await userManager.AddToRoleAsync(defaultUserAdmin, Roles.Admin.ToString());
            }
        }
    }

    public static async Task SeedUserAsync(UserManager<MVCUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        var defaultUser = new MVCUser
        {
            UserName = "user",
            Email = "user@gmail.com",
            FirstName = "user",
            LastName = "user",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "User123!");
                await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
            }
        }
    }
}