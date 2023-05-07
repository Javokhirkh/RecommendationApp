namespace RecommendationApp.Domain.Common;

public interface IEntity<TKey> : IAuditableEntity
{
    public TKey Id { get; set; }
}