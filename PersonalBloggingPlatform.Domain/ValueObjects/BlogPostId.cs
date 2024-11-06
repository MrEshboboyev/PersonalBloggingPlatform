using PersonalBloggingPlatform.Domain.Exceptions;
using System;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record BlogPostId
{
    public Guid Value { get; set; }

    public BlogPostId(Guid value)
    {
        if (value == Guid.Empty)
            throw new EmptyBlogPostIdException("value");

        Value = value;
    }

    public static implicit operator Guid(BlogPostId id)
        => id.Value;

    public static implicit operator BlogPostId(Guid id)
        => new(id);
}

