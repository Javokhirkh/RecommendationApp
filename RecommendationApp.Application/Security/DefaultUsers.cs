using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Application.Security;

public static class DefaultUsers
{
    public const string AdminPassword = "NajrC6%B";

    public static readonly User Admin = new User()
    {
        Id = Guid.Parse(""),
        FirstName = "Admin",
        UserName = "Admin",
        Email = "admin@my.com",
        EmailConfirmed = true,
    };
}