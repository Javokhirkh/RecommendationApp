namespace RecommendationApp.Application.Common;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}