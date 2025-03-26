using PersonalBloggingPlatform.Application.DTO;
using PersonalBloggingPlatform.Shared.Abstractions.Queries;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Application.Queries;

public class SearchCategories : IQuery<IEnumerable<CategoryDto>>
{
    public string SearchPhrase { get; set; }
}