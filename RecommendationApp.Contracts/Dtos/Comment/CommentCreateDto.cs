using RecommendationApp.Contracts.Mappings;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Contracts.Dtos;

public class CommentCreateDto : IMapFrom<Comment>
{
    public Guid ReviewId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }
}