using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBloggingPlatform.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class addTagAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "blogPost",
                table: "BlogPosts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "blogPost",
                table: "BlogPosts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryReadModelId",
                schema: "blogPost",
                table: "BlogPosts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "blogPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "blogPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BlogPostId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalSchema: "blogPost",
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_CategoryReadModelId",
                schema: "blogPost",
                table: "BlogPosts",
                column: "CategoryReadModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BlogPostId",
                schema: "blogPost",
                table: "Tags",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_Categories_CategoryReadModelId",
                schema: "blogPost",
                table: "BlogPosts",
                column: "CategoryReadModelId",
                principalSchema: "blogPost",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_Categories_CategoryReadModelId",
                schema: "blogPost",
                table: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "blogPost");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "blogPost");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_CategoryReadModelId",
                schema: "blogPost",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "blogPost",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "blogPost",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "CategoryReadModelId",
                schema: "blogPost",
                table: "BlogPosts");
        }
    }
}
