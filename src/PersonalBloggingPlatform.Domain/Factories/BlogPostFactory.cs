using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using System;

namespace PersonalBloggingPlatform.Domain.Factories;

public sealed class BlogPostFactory : IBlogPostFactory
{
    public BlogPost Create(PostTitle title, PostContent content, CategoryId categoryId)
        => new (title, content, categoryId, DateTime.UtcNow, DateTime.UtcNow);
}