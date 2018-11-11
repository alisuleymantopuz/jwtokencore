using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core.Shared.Contracts.Services
{
    public interface ITokenFactory
    {
        string GenerateToken(int size = 32);
    }
}
