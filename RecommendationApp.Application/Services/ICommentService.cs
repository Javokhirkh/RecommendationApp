using RecommendationApp.Contracts.Dtos;

namespace RecommendationApp.Application.Services;

public interface ICommentService
{
    Task<List<CommentDto>> GetCommentsByReviewIdAsync(Guid reviewId);
    Task<CommentDto> CreateCommentAsync(CommentCreateDto commentCreateDto);
    Task DeleteCommentAsync(Guid commentId);
}