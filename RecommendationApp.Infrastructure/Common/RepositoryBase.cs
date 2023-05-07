using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RecommendationApp.Application.Common;
using RecommendationApp.Domain.Common;
using RecommendationApp.Infrastructure.Data;

namespace RecommendationApp.Infrastructure.Common;

public abstract class RepositoryBase<T, TKey> : IRepositoryBase<T, TKey>
    where T : class, IHaveIdProp<TKey>
    where TKey : IComparable<TKey>, IEquatable<TKey>
{
    protected readonly DbSet<T> DbSet;
    protected readonly ApplicationDbContext Context;

    public RepositoryBase(ApplicationDbContext context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }

    public virtual T GetById(TKey id, bool trackChanges = false)
    {
        var query = GetQuery(trackChanges);

        return query.FirstOrDefault(x => x.Id.Equals(id));
    }

    public virtual async Task<T> GetByIdAsync(TKey id, bool trackChanges = false)
    {
        return await GetAsync(x => x.Id.Equals(id));
    }

    public virtual T Get(Expression<Func<T, bool>> expression, bool trackChanges = false)
    {
        var query = GetQuery(trackChanges);
        
        return query.FirstOrDefault(expression);
    }

    public virtual async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool trackChanges = false)
    {
        var query = GetQuery(trackChanges);
        
        return await query.FirstOrDefaultAsync(expression);
    }

    public virtual IEnumerable<T> GetAll(bool trackChanges = false)
    {
        var query = GetQuery(trackChanges);

        return query.ToList();
    }

    public virtual async Task<List<T>> GetAllAsync(bool trackChanges = false)
    {
        var query = GetQuery(trackChanges);

        return await query.ToListAsync();
    }

    public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> expression, bool trackChanges = false)
    {
        var query = GetQuery(trackChanges);

        return query.Where(expression).ToList();
    }

    public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool trackChanges = false)
    {
        var query = GetQuery(trackChanges);

        return await query.Where(expression).ToListAsync();
    }

    public virtual T Add(T entity)
    {
        DbSet.Add(entity);

        return entity;
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);

        return entity;
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        DbSet.AddRange(entities);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
    }

    public virtual T Update(T entity)
    {
        DbSet.Update(entity);

        return entity;
    }

    public virtual void UpdateRange(IEnumerable<T> entities)
    {
        DbSet.UpdateRange(entities);
    }

    public virtual void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public virtual void DeleteRange(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public virtual async Task<bool> AnyAsync()
    {
        return await DbSet.AnyAsync();
    }

    public virtual bool Any()
    {
        return DbSet.Any();
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.AnyAsync(predicate);
    }

    public virtual bool Any(Expression<Func<T, bool>> predicate)
    {
        return DbSet.Any(predicate);
    }

    public IQueryable<T> AllAsQueryable => DbSet.AsQueryable();
    
    public virtual IQueryable<T> GetQuery(bool tracking = false)
    {
        var query = AllAsQueryable;

        if (!tracking)
            query = query.AsNoTracking();

        return query;
    }
}