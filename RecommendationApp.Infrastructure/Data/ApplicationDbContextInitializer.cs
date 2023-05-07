using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecommendationApp.Application.Security;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Infrastructure.Data;

public class ApplicationDbContextInitializer : IDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;

    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await SeedRolesAsync();
            await SeedUsersAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while seeding the database");
            throw;
        }
    }

    private async Task SeedRolesAsync()
    {
        await SeedRoleAsync(DefaultRoles.Admin);
        await SeedRoleAsync(DefaultRoles.User);
    }
    
    private async Task SeedRoleAsync(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName)) return;
        
        var role = new IdentityRole<Guid>(roleName);
        var result = await _roleManager.CreateAsync(role);
        
        if (result.Succeeded) return;
        
        var errors = result.Errors.Select(x => x.Description);
        throw new Exception($"Seeding \"{roleName}\" role failed. Errors: {string.Join(",", errors)}");
    }

    private async Task SeedUsersAsync()
    {
        // seed admin user if not exists with admin role
        var adminUser = DefaultUsers.Admin;
        var adminPassword = DefaultUsers.AdminPassword;
        
        await SeedUserAsync(adminUser, adminPassword, DefaultRoles.Admin);
    }
    
    private async Task SeedUserAsync(User user, string password, string roleName)
    {
        var userEntity = await _userManager.FindByNameAsync(user.UserName);
        
        if (userEntity != null) return;
        
        var result = await _userManager.CreateAsync(user, password);
        
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, roleName);
            return;
        }
        
        var errors = result.Errors.Select(x => x.Description);
        throw new Exception($"Seeding \"{user.UserName}\" user failed. Errors: {string.Join(",", errors)}");
    }
}