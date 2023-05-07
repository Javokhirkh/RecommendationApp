namespace RecommendationApp.Application.Common;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(Guid userId);

    Task IsInRoleAsync(Guid userId, string role);

    Task AuthorizeAsync(Guid userId, string policyName);

    Task<string> CreateUserAsync(string userName, string password);

    Task DeleteUserAsync(Guid userId);
}