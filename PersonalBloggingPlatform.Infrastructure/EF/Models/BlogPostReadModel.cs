using System;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Infrastructure.EF.Models;

public class BlogPostReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
    public Guid CategoryId { get; set; }
    public CategoryReadModel Category { get; set; }
    public ICollection<TagReadModel> Tags { get; set; } = [];
    public ICollection<CommentReadModel> Comments { get; set; } = [];
}

