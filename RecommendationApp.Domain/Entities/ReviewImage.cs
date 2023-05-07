using System.ComponentModel.DataAnnotations;
using RecommendationApp.Domain.Common;

namespace RecommendationApp.Domain.Entities;

public class ReviewImage : BaseEntity<Guid>
{
    public Guid ReviewId { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    
    public Review Review { get; set; }
}