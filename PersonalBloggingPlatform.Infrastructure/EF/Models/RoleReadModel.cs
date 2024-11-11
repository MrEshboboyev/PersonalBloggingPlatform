using System.Collections.Generic;
using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Models;

public class RoleReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Name { get; set; }
    public ICollection<UserReadModel> Users { get; set; } = [];
}