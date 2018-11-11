using jwtokencore.Api.Core.Dto.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace jwtokencore.Web.Api.IntegrationTests.Controllers
{
    public class AccountsControllerTests : IClassFixture<FakeWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AccountsControllerTests(FakeWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanRegisterUserWithValidAccountDetails()
        {
            var httpResponse = await _client.PostAsync("/api/accounts", new StringContent(JsonConvert.SerializeObject(new RegisterUserRequest("Test", "Test", "test@gmail.com", "test", "123456")), Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            dynamic result = JObject.Parse(stringResponse);
            Assert.True((bool)result.success);
            Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        [Fact]
        public async Task CantRegisterUserWithInvalidAccountDetails()
        {
            var httpResponse = await _client.PostAsync("/api/accounts", new StringContent(JsonConvert.SerializeObject(new RegisterUserRequest("test1", "test1", "", "test1", "123456")), Encoding.UTF8, "application/json"));
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Contains("'Email' is not a valid email address.", stringResponse);
            Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
    }
}
