using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Domain.Factories;

public interface ICategoryFactory
{
    Category Create(CategoryName name);
}