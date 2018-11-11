using FluentValidation;
using jwtokencore.Web.Api.Models.Request;

namespace jwtokencore.Web.Api.Models.Validation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
