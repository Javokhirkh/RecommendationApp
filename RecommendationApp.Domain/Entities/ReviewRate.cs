using RecommendationApp.Domain.Common;

namespace RecommendationApp.Domain.Entities;

public class ReviewRate : BaseIEntity<Guid>
{
    public Guid ReviewId { get; set; }
    public Guid UserId { get; set; }
    public int Rate { get; set; }
    
    public Review Review { get; set; }
    public User User { get; set; }
}