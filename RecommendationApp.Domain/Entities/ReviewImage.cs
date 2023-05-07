using RecommendationApp.Domain.Common;

namespace RecommendationApp.Domain.Entities;

public class ReviewImage : BaseIEntity<Guid>
{
    public Guid ReviewId { get; set; }
    public string ImageUrl { get; set; }
    
    public Review Review { get; set; }
}