using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Domain.Factories;

public class UserFactory : IUserFactory
{
    public User Create(Username username, Email email, PasswordHash passwordHash)
        => new(username, email, passwordHash);
}
