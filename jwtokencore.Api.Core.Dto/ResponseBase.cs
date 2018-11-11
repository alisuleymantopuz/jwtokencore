using jwtokencore.Api.Core.Dto.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core.Dto
{
    public abstract class ResponseBase
    {
        protected ResponseBase(bool success = false, IEnumerable<Error> errors = null)
        {
            Success = success;
            Errors = errors;
        }
        public bool Success { get; }
        public IEnumerable<Error> Errors { get; }

    }
}
