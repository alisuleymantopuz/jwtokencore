using jwtokencore.Api.Core.Shared.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core.Authentication
{
    public sealed class UserSpecification : SpecificationBase<User>
    {
        public UserSpecification(string identityId) : base(u => u.IdentityId == identityId)
        {
            AddInclude(u => u.RefreshTokens);
        }
    }
}
