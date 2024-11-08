using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<BlogPost>,
                                           IEntityTypeConfiguration<Tag>,
                                           IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        // Configure BlogPost table
        builder.ToTable("BlogPosts");
        builder.HasKey(bp => bp.Id);

        // Converters for custom value objects
        var blogPostTitleConverter = new ValueConverter<PostTitle, string>(pt => pt.Value,
            pt => new PostTitle(pt));
        var blogPostContentConverter = new ValueConverter<PostContent, string>(pc => pc.Value, 
            pc => new PostContent(pc));

        // Id property conversion
        builder.Property(bp => bp.Id)
            .HasConversion(id => id.Value, id => new BlogPostId(id))
            .IsRequired();

        // Title property conversion
        builder.Property<PostTitle>("_title")
            .HasConversion(blogPostTitleConverter)
            .HasColumnName("Title")
            .IsRequired();

        // Content property conversion
        builder.Property<PostContent>("_content")
            .HasConversion(blogPostContentConverter)
            .HasColumnName("Content")
            .IsRequired();

        // Mapping CreatedAt and LastModified as DateTime columns
        builder.Property("_createdAt")
            .HasColumnName("CreatedAt")
            .IsRequired();

        builder.Property("_lastModified")
            .HasColumnName("LastModified")
            .IsRequired();

        // Configure relationship to Tags (one-to-many)
        builder.HasMany(typeof(Tag), "_tags");

        // Configure relationship to Category (one-to-one or many-to-one)
        builder.HasOne(typeof(Category), "_category");
    }

    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property<Guid>("Id");
        // Configure Tag properties
        builder.Property(t => t.Name);
        // Configure Tags table
        builder.ToTable("Tags");
    }

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property<Guid>("Id");
        // Configure Category properties
        builder.Property(c => c.Name);
        // Configure Categories table
        builder.ToTable("Categories");
    }
}
