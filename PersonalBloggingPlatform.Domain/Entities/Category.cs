using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;

namespace PersonalBloggingPlatform.Domain.Entities;

public class Category : AggregateRoot<Guid>
{
    private CategoryName _name;

    // Public property for accessing the name value
    public CategoryName Name => _name;

    // Private constructor for ORM support
    private Category() { }

    internal Category(CategoryName name)
    {
        Id = Guid.NewGuid();
        _name = name;
    }

    public void UpdateName(CategoryName newName)
    {
        _name = newName;
    }
}