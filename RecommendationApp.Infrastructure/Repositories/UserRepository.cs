using Microsoft.EntityFrameworkCore;
using RecommendationApp.Application.Repositories;
using RecommendationApp.Domain.Entities;
using RecommendationApp.Infrastructure.Common;
using RecommendationApp.Infrastructure.Data;

namespace RecommendationApp.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
{
    
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User> GetByUserNameAsync(string userName, bool trackChanges = false)
    {
        var query = GetQuery(trackChanges);
        
        return await query.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(userName.ToLower()));
    }
}