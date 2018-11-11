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
    public class AuthControllerTests : IClassFixture<FakeWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public AuthControllerTests(FakeWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanLoginWithValidCredentials()
        {
            var httpResponse = await _client.PostAsync("/api/auth/login", new StringContent(JsonConvert.SerializeObject(new Models.Request.LoginRequest { UserName = "ast", Password = "123456" }), Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            dynamic result = JObject.Parse(stringResponse);
            Assert.NotNull(result.accessToken.token);
            Assert.Equal(7200, (int)result.accessToken.expiresIn);
            Assert.NotNull(result.refreshToken);
        }

        [Fact]
        public async Task CantLoginWithInvalidCredentials()
        {
            var httpResponse = await _client.PostAsync("/api/auth/login", new StringContent(JsonConvert.SerializeObject(new Models.Request.LoginRequest { UserName = "unknown", Password = "test" }), Encoding.UTF8, "application/json"));
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Contains("Invalid username or password.", stringResponse);
            Assert.Equal(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        [Fact]
        public async Task CanExchangeValidRefreshToken()
        {
            var httpResponse = await _client.PostAsync("/api/auth/refreshtoken", new StringContent(JsonConvert.SerializeObject(new Models.Request.ExchangeRefreshTokenRequest { AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhc3QiLCJqdGkiOiI3ODhkMWRkYS1lMTgwLTRhZDAtODViYi02MWI5YTVlOWY5M2MiLCJpYXQiOjE1NDE4Nzc2MTgsInJvbCI6ImFwaV9hY2Nlc3MiLCJpZCI6ImIwMDYyOWUxLTU3MjktNDlkZi05MDFjLTU2M2QyMmI3NjM3ZCIsIm5iZiI6MTU0MTg3NzYxNywiZXhwIjoxNTQxODg0ODE3LCJpc3MiOiJ3ZWJBcGkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMDAvIn0.CWAks1ditBJBc1o8z8BNT-foZJtf_MNC46ZreGC__e0", RefreshToken = "4NIpI0b7hEMSl+4cpAV2Zh/dKNlY0AGANjuDoN1/8oE=" }), Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            dynamic result = JObject.Parse(stringResponse);
            Assert.NotNull(result.accessToken.token);
            Assert.Equal(7200, (int)result.accessToken.expiresIn);
            Assert.NotNull(result.refreshToken);
        }

        [Fact]
        public async Task CantExchangeInvalidRefreshToken()
        {
            var httpResponse = await _client.PostAsync("/api/auth/refreshtoken", new StringContent(JsonConvert.SerializeObject(new Models.Request.ExchangeRefreshTokenRequest { AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJtbWFjbmVpbCIsImp0aSI6IjA0YjA0N2E4LTViMjMtNDgwNi04M2IyLTg3ODVhYmViM2ZjNyIsImlhdCI6MTUzOTUzNzA4Mywicm9sIjoiYXBpX2FjY2VzcyIsImlkIjoiNDE1MzI5NDUtNTk5ZS00OTEwLTk1OTktMGU3NDAyMDE3ZmJlIiwibmJmIjoxNTM5NTM3MDgyLCJleHAiOjE1Mzk1NDQyODIsImlzcyI6IndlYkFwaSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAwMC8ifQ.xzDQOKzPZarve68Np8Iu8sh2oqoCpHSmp8fMdYRHC_k", RefreshToken = "unknown" }), Encoding.UTF8, "application/json"));
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            Assert.Contains("Invalid token.", stringResponse);
        }
    }
}
