using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<BlogPostReadModel>,
                                          IEntityTypeConfiguration<TagReadModel>,
                                          IEntityTypeConfiguration<CategoryReadModel>
{
    public void Configure(EntityTypeBuilder<BlogPostReadModel> builder)
    {
        // Configure BlogPosts table
        builder.ToTable("BlogPosts");
        builder.HasKey(bp => bp.Id);

        // Configure Category as a foreign key (many-to-one relationship)
        builder
            .Property<Guid>("CategoryId") // CategoryId as a foreign key
            .IsRequired();

        builder
            .HasOne(bp => bp.Category)
            .WithMany(c => c.BlogPosts)
            .HasForeignKey("CategoryId")
            .OnDelete(DeleteBehavior.Restrict); // Ensures that deleting a category doesn't delete blog posts

        // Configure Tags as a one-to-many relationship with BlogPostReadModel
        builder
            .HasMany(bp => bp.Tags)
            .WithOne(t => t.BlogPost)
            .HasForeignKey(t => t.BlogPostId);
    }

    public void Configure(EntityTypeBuilder<TagReadModel> builder)
    {
        // Configure Tags table
        builder.ToTable("Tags");
        builder.HasKey(t => t.Id);

        // Foreign key relationship with BlogPostReadModel
        builder
            .HasOne(t => t.BlogPost)
            .WithMany(bp => bp.Tags)
            .HasForeignKey(t => t.BlogPostId)
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<CategoryReadModel> builder)
    {
        // Configure Categories table
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);

        // Configure Category properties, if needed
        builder.Property(c => c.Name)
            .HasMaxLength(100) // Example length limit
            .IsRequired();
    }
}
