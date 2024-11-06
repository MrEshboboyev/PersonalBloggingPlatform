using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;

namespace PersonalBloggingPlatform.Domain.Events;

public record BlogPostAdded(BlogPost BlogPost) : IDomainEvent;

