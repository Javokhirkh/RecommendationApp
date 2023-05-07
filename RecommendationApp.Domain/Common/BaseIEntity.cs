using System.ComponentModel.DataAnnotations;

namespace RecommendationApp.Domain.Common;

public abstract class BaseIEntity<TKey> : IEntity<TKey>
{
    [Required]
    public TKey Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOnUtc { get; set; }
    public string IPAddress { get; set; }
    public bool IsDeleted { get; set; }
}