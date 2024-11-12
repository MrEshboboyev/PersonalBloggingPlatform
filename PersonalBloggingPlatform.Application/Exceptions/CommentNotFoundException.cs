using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;
using System;

namespace PersonalBloggingPlatform.Application.Exceptions;

public class CommentNotFoundException(Guid id) 
    : DomainException($"Comment with Id {id} not found!")
{
    public Guid Id { get; } = id;
}
