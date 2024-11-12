using PersonalBloggingPlatform.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Domain.Repositories;

public interface ICommentRepository
{
    Task<Comment> GetAsync(Guid id);
    Task CreateAsync(Comment comment);
    Task UpdateAsync(Comment comment);
}