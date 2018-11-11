using jwtokencore.Api.Core.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core.Dto.Authentication
{
    public class ExchangeRefreshTokenResponse : ProcessorResponseMessage
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }

        public ExchangeRefreshTokenResponse(bool success = false, string message = null) : base(success, message)
        {

        }

        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
