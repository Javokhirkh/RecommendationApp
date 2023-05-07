using RecommendationApp.Application.Common;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Application.Repositories;

public interface ITagRepository : IRepositoryBase<Tag, Guid>
{
}