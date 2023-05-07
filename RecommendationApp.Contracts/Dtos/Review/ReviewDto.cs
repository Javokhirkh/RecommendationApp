using RecommendationApp.Contracts.Mappings;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Contracts.Dtos;

public class ReviewDto : IMapFrom<Review>
{
    public string Name { get; set; }

    public string ReviewArtName { get; set; }
    
    public string Content { get; set; }
    
    public string ImageUrl { get; set; }
    
    public List<ReviewTag> ReviewTags { get; set; }

    public ReviewGroupDto ReviewGroup { get; set; }

    public Guid UserId { get; set; }
    
    public UserDto User { get; set; }
    
    public List<Comment> Comments { get; set; }
    
    public List<ReviewUserLike> ReviewLikes { get; set; }
    
    public float ReviewArtRate { get; set; }
    
    public float AverageRate { get; set; }
}