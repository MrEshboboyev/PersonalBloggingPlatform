using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Models;

public class CommentReadModel
{

    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModified { get; set; }
    
    public Guid BlogPostId { get; set; }
    public BlogPostReadModel BlogPost { get; set; }


    public Guid UserId { get; set; }
    public UserReadModel User { get; set; }
}

