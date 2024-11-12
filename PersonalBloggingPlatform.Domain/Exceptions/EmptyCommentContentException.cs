using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyCommentContentException : DomainException
{
    public EmptyCommentContentException() : base("Comment Content cannot be empty!")
    {
    }
}
