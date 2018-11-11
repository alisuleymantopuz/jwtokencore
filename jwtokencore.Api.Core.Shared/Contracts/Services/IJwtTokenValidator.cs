using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace jwtokencore.Api.Core.Shared.Contracts.Services
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}
