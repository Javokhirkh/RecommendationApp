using System.ComponentModel.DataAnnotations;
using RecommendationApp.Contracts.Mappings;
using RecommendationApp.Domain.Entities;
using RecommendationApp.Domain.Enums;

namespace RecommendationApp.Contracts.Dtos;

public class ReviewCreateDto : IMapFrom<Review>
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string ReviewArtName { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    public string ImageUrl { get; set; }
    
    public List<Guid> ReviewTags { get; set; }

    public ReviewGroup ReviewGroup { get; set; }

    public float ReviewArtRate { get; set; }
}