namespace RecommendationApp.Domain.Common;

public interface IHaveIdProp<TKey>
{
    public TKey Id { get; set; }
}