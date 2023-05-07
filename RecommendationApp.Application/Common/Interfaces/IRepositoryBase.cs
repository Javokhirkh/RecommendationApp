using System.Linq.Expressions;
using RecommendationApp.Domain.Common;

namespace RecommendationApp.Application.Common;

public interface IRepositoryBase<T, TKey>
    where T : IHaveIdProp<TKey>
    where TKey : IComparable<TKey>, IEquatable<TKey>
{
    T GetById(TKey id, bool trackChanges = false);
    Task<T> GetByIdAsync(TKey id, bool trackChanges = false);
    T Get(Expression<Func<T, bool>> expression, bool trackChanges = false);
    Task<T> GetAsync(Expression<Func<T, bool>> expression, bool trackChanges = false);
    IEnumerable<T> GetAll(bool trackChanges = false);
    Task<List<T>> GetAllAsync(bool trackChanges = false);
    IEnumerable<T> GetAll(Expression<Func<T, bool>> expression, bool trackChanges = false);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool trackChanges = false);
    T Add(T entity);
    Task<T> AddAsync(T entity);
    void AddRange(IEnumerable<T> entities);
    Task AddRangeAsync(IEnumerable<T> entities);
    T Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task<bool> AnyAsync();
    bool Any();
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    bool Any(Expression<Func<T, bool>> predicate);
    IQueryable<T> AllAsQueryable { get; }
}