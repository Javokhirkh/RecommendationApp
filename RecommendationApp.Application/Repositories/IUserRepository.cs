using RecommendationApp.Application.Common;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Application.Repositories;

public interface IUserRepository : IRepositoryBase<User, Guid>
{
    Task<User> GetByUserNameAsync(string userName, bool trackChanges = false);
}