using RecommendationApp.Application.Services;
using RecommendationApp.Contracts.Dtos;
using RecommendationApp.Domain.Enums;

namespace RecommendationApp.Infrastructure.Services;

public class ReviewService : IReviewService
{
    public Task<ReviewDto> CreateReviewAsync(ReviewCreateDto reviewCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<ReviewDto> GetReviewByIdAsync(Guid reviewId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReviewDto>> GetReviewsByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReviewDto>> GetReviewsByReviewGroupAsync(ReviewGroup reviewGroup)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReviewDto>> GetReviewsByTagIdAsync(Guid tagId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ReviewDto>> GetReviewsByTagNameAsync(string tagName)
    {
        throw new NotImplementedException();
    }
}