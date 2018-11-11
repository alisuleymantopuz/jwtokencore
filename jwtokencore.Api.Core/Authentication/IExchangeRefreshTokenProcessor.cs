using jwtokencore.Api.Core.Dto.Authentication;
using jwtokencore.Api.Core.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core.Authentication
{
    public interface IExchangeRefreshTokenProcessor : IProcessorRequestHandler<ExchangeRefreshTokenRequest, ExchangeRefreshTokenResponse>
    {

    }
}
