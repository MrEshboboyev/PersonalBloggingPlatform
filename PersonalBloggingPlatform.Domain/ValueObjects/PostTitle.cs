using PersonalBloggingPlatform.Domain.Exceptions;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record PostTitle
{
    public string Value { get; }

    public PostTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyPostTitleException();
        }
        Value = value;
    }

    public static implicit operator string(PostTitle title) 
        => title.Value;

    public static implicit operator PostTitle(string title) 
        => new(title);
}

