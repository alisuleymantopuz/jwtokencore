using jwtokencore.Api.Core.Dto.Authentication;
using jwtokencore.Web.Api.Presenters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Xunit;

namespace jwtokencore.Web.Api.Tests.Presenters
{
    public class LoginPresenterTests
    {
        const string token = "111333444666777";
        LoginPresenter presenter = new LoginPresenter();

        [Fact]
        public void ShouldBe_GivenSuccessfulProcessorResponse_SetsOKHttpStatusCode()
        {
            // act
            presenter.Handle(new LoginResponse(new AccessToken("", 0), "", true));

            // assert
            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void ShouldBe_GivenSuccessfulProcessorResponse_SetsAccessToken()
        {
            // act
            presenter.Handle(new LoginResponse(new AccessToken(token, 0), "", true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.Equal(token, data.accessToken.token.Value);
        }

        [Fact]
        public void ShouldBe_GivenFailedProcessorResponse_SetsErrors()
        {
            // act
            presenter.Handle(new LoginResponse(new[] { new Error("", "Invalid username/password") }));

            // assert
            var data = JsonConvert.DeserializeObject<IEnumerable<Error>>(presenter.ContentResult.Content);
            Assert.Equal((int)HttpStatusCode.Unauthorized, presenter.ContentResult.StatusCode);
            Assert.Equal("Invalid username/password", data.First().Description);
        }
    }
}
