using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBloggingPlatform.Infrastructure.EF.Models;

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

        // Map Category as a string column (assumes Category is an enum or similar)
        builder
            .Property(bp => bp.Category)
            .HasConversion(c => c.ToString(), c => new CategoryReadModel(c))
            .IsRequired();

        // Define one-to-many relationship with TagReadModel
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

        // Define foreign key relationship with BlogPostReadModel
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
    }
}
