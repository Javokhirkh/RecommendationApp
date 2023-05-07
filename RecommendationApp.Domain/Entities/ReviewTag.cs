namespace RecommendationApp.Domain.Entities;

public class ReviewTag
{
    public Guid ReviewId { get; set; }
    public Guid TagId { get; set; }
    
    public Review Review { get; set; }
    public Tag Tag { get; set; }
}