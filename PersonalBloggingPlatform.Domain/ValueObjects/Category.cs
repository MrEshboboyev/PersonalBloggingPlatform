using PersonalBloggingPlatform.Domain.Exceptions;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record Category
{
    public string Name { get; }

    public Category(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            throw new EmptyCategoryNameException();
        }

        Name = name;
    }

    public static implicit operator string(Category category)
        => category.Name;
}

