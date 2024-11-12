﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonalBloggingPlatform.Infrastructure.EF.Contexts;

#nullable disable

namespace PersonalBloggingPlatform.Infrastructure.EF.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    [Migration("20241112113301_addComment")]
    partial class addComment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("blogPost")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlogPostTags", b =>
                {
                    b.Property<Guid>("BlogPostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("BlogPostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("BlogPostTags", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Domain.Entities.BlogPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("CategoryId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastModified");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Title");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BlogPostId")
                        .HasColumnType("uuid")
                        .HasColumnName("BlogPostId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastModified");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("UserId");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Roles", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Domain.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags", "blogPost");
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Email");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Username");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users", "blogPost");
                });

            modelBuilder.Entity("UserRoles", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles", "blogPost");
                });

            modelBuilder.Entity("BlogPostTags", b =>
                {
                    b.HasOne("PersonalBloggingPlatform.Domain.Entities.BlogPost", null)
                        .WithMany()
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBloggingPlatform.Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Domain.Entities.Comment", b =>
                {
                    b.HasOne("PersonalBloggingPlatform.Domain.Entities.BlogPost", null)
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBloggingPlatform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserRoles", b =>
                {
                    b.HasOne("PersonalBloggingPlatform.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBloggingPlatform.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalBloggingPlatform.Domain.Entities.BlogPost", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}