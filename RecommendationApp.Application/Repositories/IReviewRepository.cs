using RecommendationApp.Application.Common;
using RecommendationApp.Domain.Entities;
using RecommendationApp.Domain.Enums;

namespace RecommendationApp.Application.Repositories;

public interface IReviewRepository : IRepositoryBase<Review, Guid>
{
    Task<List<Review>> GetReviewsByUserIdAsync(Guid userId, bool trackChanges = false);
    Task<List<Review>> GetReviewsByReviewGroupAsync(ReviewGroup reviewGroup, bool trackChanges = false);
    Task<List<Review>> GetReviewsByTagIdAsync(Guid tagId, bool trackChanges = false);
    Task<List<Review>> GetReviewsByTagNameAsync(string tagName, bool trackChanges = false);
}