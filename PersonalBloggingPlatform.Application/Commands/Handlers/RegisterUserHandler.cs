using PersonalBloggingPlatform.Application.Exceptions;
using PersonalBloggingPlatform.Domain.Factories;
using PersonalBloggingPlatform.Domain.Repositories;
using PersonalBloggingPlatform.Shared.Abstractions.Auth;
using PersonalBloggingPlatform.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace PersonalBloggingPlatform.Application.Commands.Handlers;

internal class RegisterUserHandler(IUserRepository userRepository,
    IUserFactory userFactory,
    IPasswordHasher passwordHasher) : ICommandHandler<RegisterUser>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUserFactory _userFactory = userFactory;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task HandleAsync(RegisterUser command)
    {
        var (username, email, password) = command;
        
        var userFromDb = await _userRepository.GetByUsernameAsync(username);

        if (userFromDb != null)
        {
            throw new UserAlreadyExistsException(username);
        }

        var passwordHash = _passwordHasher.Hash(password);
        var user = _userFactory.Create(username, email, passwordHash);    

        await _userRepository.AddAsync(user);
    }
}