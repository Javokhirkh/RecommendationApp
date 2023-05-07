using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecommendationApp.Application.Common;
using RecommendationApp.Domain.Common;

namespace RecommendationApp.Infrastructure.Data.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private const string AppUser = "Recommendation System";
    
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTimeProvider _dateTime;

    public AuditableEntitySaveChangesInterceptor(IDateTimeProvider dateTime, ICurrentUserService currentUserService)
    {
        _dateTime = dateTime;
        _currentUserService = currentUserService;
    }
    
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        AddAuditInfo(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        AddAuditInfo(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    
    private void AddAuditInfo(DbContext context)
    {
        var entities = context.ChangeTracker.Entries<IAuditableEntity>()
            .Where(x => x.State is EntityState.Added or EntityState.Modified);

        var utcNow = _dateTime.Now;
        var user = _currentUserService.GetCurrentUser();
        var ipAddress = user.IPAddress;
        var userName = user.UserName ?? AppUser;

        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedOnUtc = utcNow;
                entity.Entity.CreatedBy = userName;
                entity.CurrentValues["IsDeleted"] = false;
                
                entity.Entity.LastModifiedOnUtc = utcNow;
                entity.Entity.LastModifiedBy = userName;
            }

            if (entity.State == EntityState.Modified)
            {
                entity.Property(p => p.CreatedBy).IsModified = false;
                entity.Property(p => p.CreatedOnUtc).IsModified = false;
                
                entity.Entity.LastModifiedOnUtc = utcNow;
                entity.Entity.LastModifiedBy = userName;
            }

            // if (entity.State == EntityState.Deleted)
            // {
            //     entity.State = EntityState.Modified;
            //     entity.CurrentValues["IsDeleted"] = true;
            // }

            entity.Entity.IPAddress = ipAddress;
        }
    }
}