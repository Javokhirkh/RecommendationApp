using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecommendationApp.Contracts;

namespace RecommendationApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMappingProfiles();
        return services;
    }
}