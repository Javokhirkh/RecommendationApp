using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecommendationApp.Application.Common;
using RecommendationApp.Application.Services;
using RecommendationApp.Domain.Entities;
using RecommendationApp.Infrastructure.Data;
using RecommendationApp.Infrastructure.Data.Interceptors;
using RecommendationApp.Infrastructure.Helpers;
using RecommendationApp.Infrastructure.Services;

namespace RecommendationApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"), builder =>
            {
                builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });
            opt.EnableSensitiveDataLogging();
        });

        services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddScoped<ApplicationDbContextInitializer>();

        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IReviewService, ReviewService>();


        return services;
    }
}