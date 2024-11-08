using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System;

namespace PersonalBloggingPlatform.Application.Queries;

public class GetTag : IQuery<TagDto>
{
    public Guid Id { get; set; }
}