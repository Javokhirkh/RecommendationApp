using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using RecommendationApp.Domain.Common;
using RecommendationApp.Domain.Enums;

namespace RecommendationApp.Domain.Entities;

public class User : IdentityUser<Guid>, IHaveIdProp<Guid>, IAuditableEntity, ISoftDeletable
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public float UserRate { get; set; }
    
    
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedOnUtc { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOnUtc { get; set; }
    public string IPAddress { get; set; }
    public bool IsDeleted { get; set; }
    
    public List<Review> Reviews { get; set; }
    public List<Comment> Comments { get; set; }
    public List<ReviewUserLike> ReviewUserLikes { get; set; }
    public List<ReviewUserRate> ReviewUserRates { get; set; }
}