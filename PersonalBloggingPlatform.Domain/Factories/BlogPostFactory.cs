using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using System;

namespace PersonalBloggingPlatform.Domain.Factories;

internal class BlogPostFactory : IBlogPostFactory
{
    public BlogPost Create(BlogPostId id, PostTitle title, PostContent content)
        => new (id, title, content, DateTime.Now, DateTime.Now);
}