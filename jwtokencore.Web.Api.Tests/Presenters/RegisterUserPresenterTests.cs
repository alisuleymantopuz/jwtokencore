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
    public class RegisterUserPresenterTests
    {
        RegisterUserPresenter presenter = new RegisterUserPresenter();

        [Fact]
        public void Handle_GivenSuccessfulProcessorResponse_SetsOKHttpStatusCode()
        {
            // act
            presenter.Handle(new RegisterUserResponse("", true));

            // assert
            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void Handle_GivenSuccessfulProcessorResponse_SetsId()
        {
            // act
            presenter.Handle(new RegisterUserResponse("1234", true));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.True(data.success.Value);
            Assert.Equal("1234", data.id.Value);
        }

        [Fact]
        public void Handle_GivenFailedProcessorResponse_SetsErrors()
        {
            // act
            presenter.Handle(new RegisterUserResponse(new[] { "missing first name" }));

            // assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.False(data.success.Value);
            Assert.Equal("missing first name", data.errors.First.Value);
        }
    }
}
