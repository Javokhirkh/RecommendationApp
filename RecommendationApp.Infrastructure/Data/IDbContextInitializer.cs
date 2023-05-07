namespace RecommendationApp.Infrastructure.Data;

public interface IDbContextInitializer
{
    Task InitialiseAsync();
    Task SeedAsync();
}