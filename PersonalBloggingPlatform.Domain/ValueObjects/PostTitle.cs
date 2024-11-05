namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record PostTitle
{
    public string Value { get; }

    public PostTitle(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            // throw exception
        }
        Value = value;
    }
}

