using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Infrastructure.EF.Models;

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
            LastModified = readModel.LastModified
        };
}