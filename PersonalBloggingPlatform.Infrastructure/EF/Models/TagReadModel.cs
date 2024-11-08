using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Models;

public class TagReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid BlogPostId { get; set; }
    public BlogPostReadModel BlogPost { get; set; }
}