using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer;

public class DbInitializer : IDbInitializer
{
    private readonly MySqlContext _context;
    private readonly UserManager<ApplicationUser> _user;
    private readonly RoleManager<IdentityRole> _role;

    public DbInitializer(MySqlContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
    {
        _context = context;
        _user = user;
        _role = role;
    }

    public void Initialize()
    {
        if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;

        // Create admin:
        _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
        _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

        ApplicationUser admin = new ApplicationUser()
        {
            UserName = "felipe_admin",
            Email = "felipe_admin@email.com",
            EmailConfirmed = true,
            PhoneNumber = "+55 (11) 1234-5678",
            FirstName = "Felipe",
            LastName = "Admin"
        };

        _user.CreateAsync(admin, "Admin$1234").GetAwaiter().GetResult();
        _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

        var adminClaims = _user.AddClaimsAsync(admin, new Claim[] { 
            new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
            new Claim(JwtClaimTypes.GivenName, admin.FirstName),
            new Claim(JwtClaimTypes.GivenName, admin.LastName),
            new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
        }).Result;

        // Create user:
        _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
        _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

        ApplicationUser user = new ApplicationUser()
        {
            UserName = "felipe_user",
            Email = "felipe_user@email.com",
            EmailConfirmed = true,
            PhoneNumber = "+55 (11) 1234-5678",
            FirstName = "Felipe",
            LastName = "Client"
        };

        _user.CreateAsync(user, "User$1234").GetAwaiter().GetResult();
        _user.AddToRoleAsync(user, IdentityConfiguration.Client).GetAwaiter().GetResult();

        var userClaims = _user.AddClaimsAsync(user, new Claim[] {
            new Claim(JwtClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            new Claim(JwtClaimTypes.GivenName, user.FirstName),
            new Claim(JwtClaimTypes.GivenName, user.LastName),
            new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
        }).Result;
    }
}
