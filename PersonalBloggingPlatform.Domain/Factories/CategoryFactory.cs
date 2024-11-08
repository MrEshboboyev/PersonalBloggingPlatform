using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Domain.Factories;

internal class CategoryFactory : ICategoryFactory
{
    public Category Create(CategoryName name)
        => new(name);
}
