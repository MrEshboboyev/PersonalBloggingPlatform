using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Models;

public class BlogPostReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}

