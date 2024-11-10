using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Domain.Factories;

public class RoleFactory : IRoleFactory
{
    public Role Create(RoleName name)
        => new(name);
}
