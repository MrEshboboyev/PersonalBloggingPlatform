using PersonalBloggingPlatform.Domain.Entities;
using PersonalBloggingPlatform.Domain.ValueObjects;

namespace PersonalBloggingPlatform.Domain.Factories;

public interface IUserFactory
{
    User Create(Username username, Email email, PasswordHash passwordHash);
}