using PersonalBloggingPlatform.Domain.Exceptions;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record Tag
{
    public string Name { get; }

    public Tag(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            throw new EmptyTagNameException();
        }

        Name = name;
    }

    public static implicit operator string(Tag tag)
        => tag.Name;
}