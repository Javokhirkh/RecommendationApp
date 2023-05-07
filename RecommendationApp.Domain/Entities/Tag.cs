using System.ComponentModel.DataAnnotations;
using RecommendationApp.Domain.Common;

namespace RecommendationApp.Domain.Entities;

public class Tag : BaseAuditableEntity<Guid>
{
    [Required]
    public string Name { get; set; }
    
    public List<ReviewTag> ReviewTags { get; set; }
}