using RecommendationApp.Application.Common;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Application.Repositories;

public interface ICommentRepository : IRepositoryBase<Comment, Guid>
{
    Task<List<Comment>> GetCommentsByReviewIdAsync(Guid reviewId);
}