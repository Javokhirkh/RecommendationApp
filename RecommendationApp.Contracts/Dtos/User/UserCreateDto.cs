using System.ComponentModel.DataAnnotations;
using RecommendationApp.Contracts.Mappings;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Contracts.Dtos;

public class UserCreateDto : IMapFrom<User>
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; } 
}