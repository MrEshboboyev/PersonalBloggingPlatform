using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.HasKey(bp => bp.Id);

        var blogPostTitleConverter = new ValueConverter<PostTitle, string>(pn => pn.Value, 
            pn => new PostTitle(pn));

        var blogPostContentConverter = new ValueConverter<PostContent, string>(pn => pn.Value,
            pn => new PostContent(pn));

        builder.Property<PostTitle>("_title")
            .HasConversion(blogPostTitleConverter)
            .HasColumnName("Title");

        builder.Property<PostContent>("_content")
            .HasConversion(blogPostContentConverter)
            .HasColumnName("Post");

        builder.ToTable("BlogPosts");
    }
}
