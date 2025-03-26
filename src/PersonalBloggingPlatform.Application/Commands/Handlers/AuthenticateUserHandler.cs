using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Auth;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

public class AuthenticateUserHandler(IUserRepository userRepository, 
    IJwtProvider jwtProvider,
    IPasswordHasher passwordHasher) : ICommandHandler<AuthenticateUser, string>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<string> HandleAsync(AuthenticateUser command)
    {
        var user = await _userRepository.GetByUsernameAsync(command.Username);
        if (user == null || !_passwordHasher.Verify(command.Password, user.PasswordHash.Value))
        {
            throw new InvalidCredentialException();
        }

        List<string> roles = user.Roles.Select(x => x.Name.Value).ToList();

        return _jwtProvider.GenerateJwtToken(user.Id, roles);
    }
}