﻿using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;

namespace PersonalBloggingPlatform.Domain.Exceptions;

public class EmptyBlogPostIdException() : DomainException("Blog Post Id cannot be empty!")
{
}
