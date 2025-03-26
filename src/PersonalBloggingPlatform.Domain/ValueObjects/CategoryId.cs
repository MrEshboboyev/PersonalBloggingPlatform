using PersonalBloggingPlatform.Domain.Exceptions;
using System;

namespace PersonalBloggingPlatform.Domain.ValueObjects;

public record CategoryId
{
    public Guid Value { get; }

    public CategoryId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyCategoryIdException();
        }
        Value = value;
    }

    public static implicit operator Guid(CategoryId id)
        => id.Value;

    public static implicit operator CategoryId(Guid value)
        => new(value);
}
