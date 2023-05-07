using RecommendationApp.Contracts.Mappings;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Contracts.Dtos;

public class UserUpdateDto : IMapFrom<User>
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}