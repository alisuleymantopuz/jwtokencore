using System.Threading.Tasks;
using jwtokencore.Api.Core.Authentication;
using jwtokencore.Api.Core.Dto.Authentication;
using jwtokencore.Web.Api.Models.Settings;
using jwtokencore.Web.Api.Presenters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace jwtokencore.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginProcessor _loginProcessor;
        private readonly LoginPresenter _loginPresenter;
        private readonly IExchangeRefreshTokenProcessor _exchangeRefreshTokenProcessor;
        private readonly ExchangeRefreshTokenPresenter _exchangeRefreshTokenPresenter;
        private readonly AuthSettings _authSettings;

        public AuthController(ILoginProcessor loginProcessor, LoginPresenter loginPresenter, IExchangeRefreshTokenProcessor exchangeRefreshTokenProcessor, ExchangeRefreshTokenPresenter exchangeRefreshTokenPresenter, IOptions<AuthSettings> authSettings)
        {
            _loginProcessor = loginProcessor;
            _loginPresenter = loginPresenter;
            _exchangeRefreshTokenProcessor = exchangeRefreshTokenProcessor;
            _exchangeRefreshTokenPresenter = exchangeRefreshTokenPresenter;
            _authSettings = authSettings.Value;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Models.Request.LoginRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _loginProcessor.Handle(new LoginRequest(request.UserName, request.Password, Request.HttpContext.Connection.RemoteIpAddress?.ToString()), _loginPresenter);
            return _loginPresenter.ContentResult;
        }

        // POST api/auth/refreshtoken
        [HttpPost("refreshtoken")]
        public async Task<ActionResult> RefreshToken([FromBody] Models.Request.ExchangeRefreshTokenRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState);}
            await _exchangeRefreshTokenProcessor.Handle(new ExchangeRefreshTokenRequest(request.AccessToken, request.RefreshToken, _authSettings.SecretKey), _exchangeRefreshTokenPresenter);
            return _exchangeRefreshTokenPresenter.ContentResult;
        }
    }
}
