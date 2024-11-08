using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Application.Queries;

public class SearchTags : IQuery<IEnumerable<TagDto>>
{
    public string SearchPhrase { get; set; }
}