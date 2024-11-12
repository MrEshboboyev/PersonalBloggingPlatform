using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;
using System;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class BlogPostCommentNotFoundException(Guid commentId) 
    : DomainException($"BlogPost Comment with Id {commentId} was not found!")
{
    public Guid CommentId { get; set; } = commentId;
}