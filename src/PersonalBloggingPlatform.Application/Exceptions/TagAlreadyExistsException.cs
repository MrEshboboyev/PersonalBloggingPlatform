using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Application.Exceptions;

internal class TagAlreadyExistsException(string name)
    : DomainException($"Tag with name {name} already exists!")
{
    public string Name { get; } = name;
}