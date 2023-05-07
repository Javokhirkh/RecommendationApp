using RecommendationApp.Application.Repositories;
using RecommendationApp.Domain.Entities;
using RecommendationApp.Infrastructure.Common;
using RecommendationApp.Infrastructure.Data;

namespace RecommendationApp.Infrastructure.Repositories;

public class CommentRepository : RepositoryBase<Comment, Guid>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<Comment>> GetCommentsByReviewIdAsync(Guid reviewId)
    {
        return await GetAllAsync(x => x.ReviewId == reviewId);
    }
}