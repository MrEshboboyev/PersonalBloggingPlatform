using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBloggingPlatform.Infrastructure.EF.Models;

namespace PersonalBloggingPlatform.Infrastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<BlogPostReadModel>
{
    public void Configure(EntityTypeBuilder<BlogPostReadModel> builder)
    {
        builder.ToTable("BlogPosts");
        builder.HasKey(bp => bp.Id);
    }
}
