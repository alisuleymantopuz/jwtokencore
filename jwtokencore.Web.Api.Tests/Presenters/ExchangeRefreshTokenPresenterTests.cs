using jwtokencore.Api.Core.Dto.Authentication;
using jwtokencore.Web.Api.Presenters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace jwtokencore.Web.Api.Tests.Presenters
{
    public class ExchangeRefreshTokenPresenterTests
    {
        const string token = "111333444666777";
        ExchangeRefreshTokenPresenter presenter = new ExchangeRefreshTokenPresenter();

        [Fact]
        public void ShouldBe_GivenSuccessfulProcessorResponse_SetsAccessToken()
        {
            // act
            presenter.Handle(new ExchangeRefreshTokenResponse(new AccessToken(token, 0), "", true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);

            Assert.Equal(token, data.accessToken.token.Value);
        }

        [Fact]
        public void ShouldBe_GivenSuccessfulProcessorResponse_SetsRefreshToken()
        {
            // act
            presenter.Handle(new ExchangeRefreshTokenResponse(null, token, true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.Equal(token, data.refreshToken.Value);
        }

        [Fact]
        public void ShouldBe_GivenFailedProcessorResponse_SetsError()
        {
            // act
            presenter.Handle(new ExchangeRefreshTokenResponse(false, "Invalid Token."));

            // assert
            var data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.Equal((int)HttpStatusCode.BadRequest, presenter.ContentResult.StatusCode);
            Assert.Equal("Invalid Token.", data);
        }
    }
}
