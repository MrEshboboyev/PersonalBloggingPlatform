using PersonalBloggingPlatform.Shared.Abstractions.Domain;
using System;

namespace PersonalBloggingPlatform.Domain.Events;

public record BlogPostDeleted(Guid blogPostId) : IDomainEvent;

