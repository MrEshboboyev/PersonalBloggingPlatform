using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System;

namespace PersonalBloggingPlatform.Application.Queries;

public class GetCategory : IQuery<CategoryDto>
{
    public Guid Id { get; set; }
}