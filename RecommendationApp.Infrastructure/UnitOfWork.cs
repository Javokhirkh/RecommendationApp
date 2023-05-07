using RecommendationApp.Application.Common;
using RecommendationApp.Application.Repositories;
using RecommendationApp.Infrastructure.Data;
using RecommendationApp.Infrastructure.Repositories;

namespace RecommendationApp.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    private ICommentRepository _commentRepository;
    private IReviewRepository _reviewRepository;
    private IUserRepository _userRepository;

    public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_context);
    public IReviewRepository ReviewRepository => _reviewRepository ?? new ReviewRepository(_context);
    public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);
    
    
    public int Commit()
    {
        return _context.SaveChanges();
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Rollback()
    {
        _context.Database.CurrentTransaction?.Rollback();
    }

    public async Task RollbackAsync()
    {
        if(_context.Database.CurrentTransaction != null)
            await _context.Database.CurrentTransaction.RollbackAsync();
    }

    public void BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _context.Database.CurrentTransaction?.Commit();
    }

    public void RollbackTransaction()
    {
        _context.Database.CurrentTransaction?.Rollback();
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}