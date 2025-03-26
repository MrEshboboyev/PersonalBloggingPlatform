using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using System;

namespace PersonalBloggingPlatform.Domain.Factories;

public class CommentFactory : ICommentFactory
{
    public Comment Create(Guid blogPostId, Guid userId, CommentContent content)
        => new(blogPostId, userId, content);
}
