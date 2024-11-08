using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using System;

namespace PersonalBloggingPlatform.Domain.Factories;

public sealed class BlogPostFactory : IBlogPostFactory
{
    public BlogPost Create(PostTitle title, PostContent content)
        => new (title, content, DateTime.UtcNow, DateTime.UtcNow);
}