﻿using PersonalBloggingPlatform.Shared.Abstractions.Exceptions;
using System;

namespace PersonalBloggingPlatform.Application.Exceptions;

public class CategoryNotFoundException(Guid id) 
    : DomainException($"Category with Id {id} not found!")
{
    public Guid Id { get; } = id;
}