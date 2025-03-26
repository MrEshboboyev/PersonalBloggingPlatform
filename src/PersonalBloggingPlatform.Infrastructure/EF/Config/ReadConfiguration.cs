using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Infrastructure.EF.Config;

internal sealed class ReadConfiguration : IEntityTypeConfiguration<BlogPostReadModel>,
                                          IEntityTypeConfiguration<TagReadModel>,
                                          IEntityTypeConfiguration<CategoryReadModel>,
                                          IEntityTypeConfiguration<UserReadModel>,
                                          IEntityTypeConfiguration<RoleReadModel>,
                                          IEntityTypeConfiguration<CommentReadModel>
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

        builder.HasMany(bp => bp.Tags)
               .WithMany()  // No navigation property in TagReadModel
               .UsingEntity<Dictionary<string, object>>(
                   "BlogPostTags",
                   j => j.HasOne<TagReadModel>().WithMany().HasForeignKey("TagId"),
                   j => j.HasOne<BlogPostReadModel>().WithMany().HasForeignKey("BlogPostId")
               );
    }

    public void Configure(EntityTypeBuilder<TagReadModel> builder)
    {
        // Configure Tags table
        builder.ToTable("Tags");
        builder.HasKey(t => t.Id);
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

    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        // Many-to-many relationship with Role via UserRoles join table
        builder.HasMany(u => u.Roles)
               .WithMany()
               .UsingEntity<Dictionary<string, object>>(
                   "UserRoles",
                   j => j.HasOne<RoleReadModel>().WithMany().HasForeignKey("RoleId"),
                   j => j.HasOne<UserReadModel>().WithMany().HasForeignKey("UserId")
               );
    }

    public void Configure(EntityTypeBuilder<RoleReadModel> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);
    }

    public void Configure(EntityTypeBuilder<CommentReadModel> builder)
    {
        // Configure Comments table
        builder.ToTable("Comments");
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Content)
               .HasColumnName("Content")
               .IsRequired();

        builder.Property(c => c.CreatedAt)
               .HasColumnName("CreatedAt")
               .IsRequired();

        builder.Property(c => c.LastModified)
               .HasColumnName("LastModified");

        builder.Property(c => c.UserId)
               .HasColumnName("UserId")
               .IsRequired();

        builder.Property(c => c.BlogPostId)
               .HasColumnName("BlogPostId")
               .IsRequired();

        // Relationships
        builder.HasOne(c => c.User)
               .WithMany()
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.BlogPost)
               .WithMany(bp => bp.Comments) 
               .HasForeignKey(c => c.BlogPostId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
