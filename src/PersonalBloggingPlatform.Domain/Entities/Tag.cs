using PersonalBloggingPlatform.Domain.Events;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;

namespace PersonalBloggingPlatform.Domain.Entities;

public class Tag : AggregateRoot<Guid>
{
    private TagName _name;

    // Public property for accessing the name value
    public TagName Name => _name;

    // Private constructor for ORM support
    private Tag() { }

    internal Tag(TagName name)
    {
        Id = Guid.NewGuid();
        _name = name;

        AddEvent(new TagCreated(this));
    }

    public void UpdateName(TagName newName)
    {
        _name = newName;
        AddEvent(new TagUpdated(this));
    }
}