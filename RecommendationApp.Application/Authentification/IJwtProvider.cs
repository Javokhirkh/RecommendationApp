using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Application.Authentification;

public interface IJwtProvider
{
    /// <summary>
    ///   Generate JWT token
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    string Generate(User user);
}