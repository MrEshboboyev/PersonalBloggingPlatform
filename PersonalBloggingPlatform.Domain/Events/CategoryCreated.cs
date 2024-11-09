using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Shared.Abstractions.Domain;

namespace PersonalBloggingPlatform.Domain.Events;

public record CategoryCreated(Category Category) : IDomainEvent;