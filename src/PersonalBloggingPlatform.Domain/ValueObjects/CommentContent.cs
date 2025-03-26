using PersonalBloggingPlatform.Domain.Exceptions;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record CommentContent
{
    public string Value { get; }

    public CommentContent(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyCommentContentException();
        }
        Value = value;
    }

    public static implicit operator string(CommentContent content)
        => content.Value;

    public static implicit operator CommentContent(string content)
        => new(content);
}