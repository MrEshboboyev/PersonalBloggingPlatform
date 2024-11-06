using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System;

namespace PersonalBloggingPlatform.Application.Queries;

public class GetBlogPost : IQuery<BlogPostDto>
{
    public Guid Id { get; set; }
}