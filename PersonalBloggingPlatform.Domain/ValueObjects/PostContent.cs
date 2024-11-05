namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record PostContent
{
    public string Value { get; }

    public PostContent(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            // throw exception
        }
        Value = value;
    }
}

