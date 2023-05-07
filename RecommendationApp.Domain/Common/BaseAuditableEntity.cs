namespace RecommendationApp.Domain.Common;

public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity, ISoftDeletable
{
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOnUtc { get; set; }
    public string IPAddress { get; set; }
    
    public bool IsDeleted { get; set; }
}