using System.Collections.Generic;
using System;

namespace PersonalBloggingPlatform.Infrastructure.EF.Models;

public class UserReadModel
{
    public Guid Id { get; set; }
    public int Version { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public ICollection<RoleReadModel> Roles { get; set; } = [];
}
