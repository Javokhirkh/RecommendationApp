using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Infrastructure.Data.Configurations;

public class ReviewUserLikeConfiguration : IEntityTypeConfiguration<ReviewUserLike>
{
    public void Configure(EntityTypeBuilder<ReviewUserLike> builder)
    {
        builder.HasKey(x => new { x.ReviewId, x.UserId });

        builder.HasOne(x => x.Review)
            .WithMany(x => x.ReviewUserLikes)
            .HasForeignKey(x => x.ReviewId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany(x => x.ReviewUserLikes)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}