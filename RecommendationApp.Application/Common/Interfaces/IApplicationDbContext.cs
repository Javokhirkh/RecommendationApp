using Microsoft.EntityFrameworkCore;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Application.Common;

public interface IApplicationDbContext
{
    DbSet<Review> Reviews { get; set; }
    DbSet<ReviewImage> ReviewImages { get; set; }
    DbSet<ReviewUserRate> ReviewRates { get; set; }
    DbSet<ReviewTag> ReviewTags { get; set; }
    DbSet<ReviewUserLike> ReviewUserLikes { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<Tag> Tags { get; set; }
    DbSet<User> Users { get; set; }
}