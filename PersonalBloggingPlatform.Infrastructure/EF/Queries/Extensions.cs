using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Infrastructure.EF.Models;
using System.Linq;

namespace PersonalBloggingPlatform.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static BlogPostDto AsDto(this BlogPostReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Title = readModel.Title,
            Content = readModel.Content,
            CreatedAt = readModel.CreatedAt,
            LastModified = readModel.LastModified,
            Tags = readModel.Tags.Select(t => new TagDto
            {
                Id = t.Id,
                Name = t.Name
            }),
            Category = new CategoryDto
            { 
                Id = readModel.Category.Id,
                Name = readModel.Category?.Name
            }
        };

    public static TagDto AsDto(this TagReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Name = readModel?.Name
        };

    public static CategoryDto AsDto(this CategoryReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Name = readModel?.Name
        };

    public static CommentDto AsDto(this CommentReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Content = readModel?.Content
        };
}