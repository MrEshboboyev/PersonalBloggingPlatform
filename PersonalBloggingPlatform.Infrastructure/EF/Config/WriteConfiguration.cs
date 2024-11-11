using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Infrastructure.EF.Config;

internal sealed class WriteConfiguration : IEntityTypeConfiguration<BlogPost>,
                                           IEntityTypeConfiguration<Tag>,
                                           IEntityTypeConfiguration<Category>,
                                           IEntityTypeConfiguration<User>,
                                           IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        // Configure BlogPosts table
        builder.ToTable("BlogPosts");
        builder.HasKey(bp => bp.Id);

        // Value converters for custom value objects
        var blogPostTitleConverter = new ValueConverter<PostTitle, string>(
            pt => pt.Value,
            pt => new PostTitle(pt)
        );

        var blogPostContentConverter = new ValueConverter<PostContent, string>(
            pc => pc.Value,
            pc => new PostContent(pc)
        );

        var categoryIdConverter = new ValueConverter<CategoryId, Guid>(
            ci => ci.Value,
            ci => new CategoryId(ci)
        );

        builder.Property(bp => bp.Id)
            .IsRequired();

        // Configure Title and Content with converters
        builder.Property(bp => bp.Title)
            .HasConversion(blogPostTitleConverter)
            .HasColumnName("Title")
            .IsRequired();

        builder.Property(bp => bp.Content)
            .HasConversion(blogPostContentConverter)
            .HasColumnName("Content")
            .IsRequired();

        // Configure CreatedAt and LastModified as DateTime columns
        builder.Property(bp => bp.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired();

        builder.Property(bp => bp.LastModified)
            .HasColumnName("LastModified")
            .IsRequired();

        // Configure CategoryId as a foreign key using CategoryId value object
        builder.Property(bp => bp.CategoryId)
            .HasConversion(categoryIdConverter)
            .HasColumnName("CategoryId")
            .IsRequired();

        // Configure relationship with Tag via join table for many-to-many
        builder.HasMany(bp => bp.Tags)
               .WithMany()
               .UsingEntity<Dictionary<string, object>>(
                   "BlogPostTags",                           // Join table name
                   j => j.HasOne<Tag>().WithMany().HasForeignKey("TagId"),
                   j => j.HasOne<BlogPost>().WithMany().HasForeignKey("BlogPostId")
               );
    }

    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        // Configure Tags table
        builder.ToTable("Tags");
        builder.HasKey(t => t.Id);

        // Configure Tag properties with a ValueConverter for TagName
        var tagNameConverter = new ValueConverter<TagName, string>(tn => tn.Value, 
            tn => new TagName(tn));

        builder.Property<TagName>("_name")
               .HasConversion(tagNameConverter)
               .HasColumnName("Name")
               .IsRequired();
    }

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Configure Categories table
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);

        // Configure Category properties with a ValueConverter for CategoryName
        var categoryNameConverter = new ValueConverter<CategoryName, string>(cn => cn.Value, 
            cn => new CategoryName(cn));

        builder.Property<CategoryName>("_name")
               .HasConversion(categoryNameConverter)
               .HasColumnName("Name")
               .IsRequired();
    }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).IsRequired();

        var usernameConverter = new ValueConverter<Username, string>(
            u => u.Value,
            u => new Username(u)
        );

        builder.Property(u => u.Username)
            .HasConversion(usernameConverter)
            .HasColumnName("Username")
            .IsRequired();


        var emailConverter = new ValueConverter<Email, string>(
            e => e.Value,
            e => new Email(e)
        );

        builder.Property(u => u.Email)
            .HasConversion(emailConverter)
            .HasColumnName("Email")
            .IsRequired();


        var passwordHashConverter = new ValueConverter<PasswordHash, string>(
            ph => ph.Value,
            ph => new PasswordHash(ph)
        );

        builder.Property(u => u.PasswordHash)
            .HasConversion(passwordHashConverter)
            .HasColumnName("PasswordHash")
            .IsRequired();


        // Many-to-many relationship with Role
        builder.HasMany(u => u.Roles)
               .WithMany(r => r.Users)
               .UsingEntity<Dictionary<string, object>>(
                   "UserRoles",
                   j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                   j => j.HasOne<User>().WithMany().HasForeignKey("UserId")
               );
    }

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).IsRequired();

        var roleNameConverter = new ValueConverter<RoleName, string>(
            rn => rn.Value,
            rn => new RoleName(rn)
        );

        builder.Property(u => u.Name)
            .HasConversion(roleNameConverter)
            .HasColumnName("Name")
            .IsRequired();
    }
}
