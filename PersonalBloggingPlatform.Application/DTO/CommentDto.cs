using System;

namespace PersonalBloggingPlatform.Application.DTO;

public class CommentDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BlogPostId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModified { get; set; }
    public string Content { get; set; }
}