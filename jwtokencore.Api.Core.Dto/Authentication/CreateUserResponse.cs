using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core.Dto.Authentication
{
    public sealed class CreateUserResponse : ResponseBase
    {
        public string Id { get; }
        public CreateUserResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}
