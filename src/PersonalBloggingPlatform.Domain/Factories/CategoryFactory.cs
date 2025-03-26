using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Domain.Factories;

public class CategoryFactory : ICategoryFactory
{
    public Category Create(CategoryName name)
        => new(name);
}
