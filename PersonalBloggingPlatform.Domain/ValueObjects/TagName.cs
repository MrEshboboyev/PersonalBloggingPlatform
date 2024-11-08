using PersonalBloggingPlatform.Domain.Exceptions;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record TagName
{
    public string Value { get; }

    public TagName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyTagNameException();
        }
        Value = value;
    }

    public static implicit operator string(TagName title)
        => title.Value;

    public static implicit operator TagName(string title)
        => new(title);
}