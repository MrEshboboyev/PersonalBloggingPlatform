﻿using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;

namespace PersonalBloggingPlatform.Domain.Events;

public record TagRemovedFromBlogPost(BlogPost BlogPost, Tag Tag) : IDomainEvent;

