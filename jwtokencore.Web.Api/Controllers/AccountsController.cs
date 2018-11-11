using System.Threading.Tasks;
using jwtokencore.Api.Core.Authentication;
using jwtokencore.Api.Core.Dto.Authentication;
using jwtokencore.Web.Api.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace jwtokencore.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterUserProcessor _registerUserProcessor;
        private readonly RegisterUserPresenter _registerUserPresenter;

        public AccountsController(IRegisterUserProcessor registerUserProcessor, RegisterUserPresenter registerUserPresenter)
        {
            _registerUserProcessor = registerUserProcessor;
            _registerUserPresenter = registerUserPresenter;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _registerUserProcessor.Handle(new RegisterUserRequest(request.FirstName, request.LastName, request.Email, request.UserName, request.Password), _registerUserPresenter);

            return _registerUserPresenter.ContentResult;
        }
    }
}
