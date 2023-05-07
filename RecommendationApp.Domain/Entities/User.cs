using System.ComponentModel.DataAnnotations;
using RecommendationApp.Domain.Common;
using RecommendationApp.Domain.Enums;

namespace RecommendationApp.Domain.Entities;

public class User : BaseIEntity<Guid>
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public RoleType Role { get; set; }
    public string ProfileImage { get; set; }
    public float UserRate { get; set; }
}