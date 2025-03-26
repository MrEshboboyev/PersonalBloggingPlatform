using System;

namespace PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

public abstract class DomainException(string message) : Exception(message)
{
}