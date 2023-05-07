using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecommendationApp.Domain.Entities;

namespace RecommendationApp.Infrastructure.Data.Configurations;

public class ReviewImageConfiguration: IEntityTypeConfiguration<ReviewImage>
{
    public void Configure(EntityTypeBuilder<ReviewImage> builder)
    {
        builder.HasOne(x => x.Review)
            .WithMany(x => x.ReviewImages)
            .HasForeignKey(x => x.ReviewId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.ImageUrl)
            .IsRequired();
    }
}