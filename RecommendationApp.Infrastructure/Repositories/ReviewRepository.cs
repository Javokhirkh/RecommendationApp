using RecommendationApp.Application.Repositories;
using RecommendationApp.Domain.Entities;
using RecommendationApp.Domain.Enums;
using RecommendationApp.Infrastructure.Common;
using RecommendationApp.Infrastructure.Data;

namespace RecommendationApp.Infrastructure.Repositories;

public class ReviewRepository: RepositoryBase<Review, Guid>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task<List<Review>> GetReviewsByUserIdAsync(Guid userId, bool trackChanges = false)
    {
        throw new NotImplementedException();
    }

    public Task<List<Review>> GetReviewsByReviewGroupAsync(ReviewGroup reviewGroup, bool trackChanges = false)
    {
        throw new NotImplementedException();
    }

    public Task<List<Review>> GetReviewsByTagIdAsync(Guid tagId, bool trackChanges = false)
    {
        throw new NotImplementedException();
    }

    public Task<List<Review>> GetReviewsByTagNameAsync(string tagName, bool trackChanges = false)
    {
        throw new NotImplementedException();
    }
}