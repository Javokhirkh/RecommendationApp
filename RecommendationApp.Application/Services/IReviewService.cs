using RecommendationApp.Contracts.Dtos;
using RecommendationApp.Domain.Enums;

namespace RecommendationApp.Application.Services;

public interface IReviewService
{
    Task<ReviewDto> CreateReviewAsync(ReviewCreateDto reviewCreateDto);
    Task<ReviewDto> GetReviewByIdAsync(Guid reviewId);
    Task<List<ReviewDto>> GetReviewsByUserIdAsync(Guid userId);
    Task<List<ReviewDto>> GetReviewsByReviewGroupAsync(ReviewGroup reviewGroup);
    Task<List<ReviewDto>> GetReviewsByTagIdAsync(Guid tagId);
    Task<List<ReviewDto>> GetReviewsByTagNameAsync(string tagName);
}