using System.ComponentModel.DataAnnotations;
using RecommendationApp.Domain.Common;
using RecommendationApp.Domain.Enums;

namespace RecommendationApp.Domain.Entities;

public class Review : BaseAuditableEntity<Guid>
{
    [Required]
    public string Name { get; set; }

    public string ReviewArtName { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    public string ImageUrl { get; set; }
    
    public ReviewGroup ReviewGroup { get; set; }

    public Guid UserId { get; set; }
    
    public float ReviewArtRate { get; set; }
    
    public float AverageRate { get; set; }
    
    
    public User User { get; set; }
    public List<Comment> Comments { get; set; }
    
    public List<ReviewUserLike> ReviewUserLikes { get; set; }
    public List<ReviewUserRate> ReviewUserRates { get; set; }
    
    public List<ReviewTag> ReviewTags { get; set; }
    public List<ReviewImage> ReviewImages { get; set; }
}