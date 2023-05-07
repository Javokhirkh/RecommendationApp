using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Infrastructure.Data.Configurations;

public class ReviewTagConfiguration: IEntityTypeConfiguration<ReviewTag>
{
    public void Configure(EntityTypeBuilder<ReviewTag> builder)
    {
        builder.HasKey(x => new { x.ReviewId, x.TagId });

        builder.HasOne(x => x.Review)
            .WithMany(x => x.ReviewTags)
            .HasForeignKey(x => x.ReviewId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Tag)
            .WithMany(x => x.ReviewTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}