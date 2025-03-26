using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;
using System;

namespace PersonalBloggingPlatform.Application.Exceptions;

public class BlogPostNotFoundException(Guid id) 
    : DomainException($"Blog Post with Id {id} not found!")
{
    public Guid Id { get; } = id;
}
