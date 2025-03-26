using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;
using System;

namespace PersonalBloggingPlatform.Application.Exceptions;

public class TagNotFoundException(Guid id) 
    : DomainException($"Tag with Id {id} not found!")
{
    public Guid Id { get; } = id;
}
