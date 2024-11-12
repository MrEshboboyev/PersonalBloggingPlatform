using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using System;

namespace PersonalBloggingPlatform.Domain.Factories;

public interface ICommentFactory
{
    Comment Create(Guid blogPostId, Guid userId, CommentContent content);
}