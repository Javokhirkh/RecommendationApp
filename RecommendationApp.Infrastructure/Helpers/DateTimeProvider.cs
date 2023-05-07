using RecommendationApp.Application.Common;

namespace RecommendationApp.Infrastructure.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}