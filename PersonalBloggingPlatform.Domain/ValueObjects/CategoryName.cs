using PersonalBloggingPlatform.Domain.Exceptions;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record CategoryName
{
    public string Value { get; }

    public CategoryName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyCategoryNameException();
        }
        Value = value;
    }

    public static implicit operator string(CategoryName title)
        => title.Value;

    public static implicit operator CategoryName(string title)
        => new(title);
}