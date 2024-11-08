﻿using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Domain.Factories;

internal class TagFactory : ITagFactory
{
    public Tag Create(TagName name)
        => new(name);
}