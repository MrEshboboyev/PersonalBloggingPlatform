using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Application.Exceptions;

internal class CategoryAlreadyExistsException(string name)
    : DomainException($"Category with name {name} already exists!")
{
    public string Name { get; } = name;
}