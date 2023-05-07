using RecommendationApp.Application.Repositories;

namespace RecommendationApp.Application.Common;

public interface IUnitOfWork
{
    ICommentRepository CommentRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IUserRepository UserRepository { get; }
    
    int Commit();
    Task<int> CommitAsync();
    void Rollback();
    Task RollbackAsync();
    
    void BeginTransaction();
    void CommitTransaction();
    void RollbackTransaction();
    
    void Dispose();
}