﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;

#nullable disable

namespace PersonalBloggingPlatform.Infrastructure.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("blogPost")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonalBloggingPlatform.Infrastructure.EF.Models.BlogPostReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CategoryReadModelId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryReadModelId");

                    b.ToTable("BlogPosts", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Infrastructure.EF.Models.CategoryReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Infrastructure.EF.Models.TagReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlogPostId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.ToTable("Tags", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Infrastructure.EF.Models.BlogPostReadModel", b =>
                {
                    b.HasOne("PersonalBloggingPlatform.Infrastructure.EF.Models.CategoryReadModel", null)
                        .WithMany("BlogPosts")
                        .HasForeignKey("CategoryReadModelId");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Infrastructure.EF.Models.TagReadModel", b =>
                {
                    b.HasOne("PersonalBloggingPlatform.Infrastructure.EF.Models.BlogPostReadModel", "BlogPost")
                        .WithMany("Tags")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Infrastructure.EF.Models.BlogPostReadModel", b =>
                {
                    b.Navigation("Tags");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Infrastructure.EF.Models.CategoryReadModel", b =>
                {
                    b.Navigation("BlogPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
