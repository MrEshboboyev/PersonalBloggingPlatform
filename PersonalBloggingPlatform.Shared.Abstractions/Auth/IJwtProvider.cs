using System;
using System.Collections.Generic;

namespace PersonalBloggingPlatform.Shared.Abstractions.Auth;

public interface IJwtProvider
{
    string GenerateJwtToken(Guid userId, IEnumerable<string> roles);
}