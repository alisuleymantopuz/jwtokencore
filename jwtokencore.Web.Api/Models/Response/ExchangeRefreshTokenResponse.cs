using jwtokencore.Api.Core.Dto.Authentication;

namespace jwtokencore.Web.Api.Models.Response
{
    public class ExchangeRefreshTokenResponse
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }

        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
