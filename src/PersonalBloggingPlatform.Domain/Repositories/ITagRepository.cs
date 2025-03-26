using PersonalBloggingPlatform.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace PersonalBloggingPlatform.Domain.Repositories;

public interface ITagRepository
{
    Task<Tag> GetAsync(Guid id);
    Task CreateAsync(Tag tag);
    Task UpdateAsync(Tag tag);
}