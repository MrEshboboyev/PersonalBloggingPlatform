using PersonalBloggingPlatform.Domain.Exceptions;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record PostContent
{
    public string Value { get; }

    public PostContent(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyPostContentException();
        }
        Value = value;
    }

    public static implicit operator string(PostContent content)
        => content.Value;

    public static implicit operator PostContent(string content)
        => new(content);
}