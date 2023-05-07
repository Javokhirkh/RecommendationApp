using System.ComponentModel.DataAnnotations;

namespace RecommendationApp.Domain.Common;

public abstract class BaseEntity<TKey> : IHaveIdProp<TKey>
{
    public TKey Id { get; set; }
}