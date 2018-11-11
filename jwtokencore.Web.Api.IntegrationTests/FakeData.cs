using jwtokencore.Api.Core.Authentication;
using jwtokencore.Api.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Web.Api.IntegrationTests
{
    public class FakeData
    {
        public static AppUser GetAppUser
        {
            get
            {
                return new AppUser
                {
                    Id = "b00629e1-5729-49df-901c-563d22b7637d",
                    UserName = "ast",
                    NormalizedUserName = "AST",
                    Email = "ast@contoso.com",
                    NormalizedEmail = "AST@CONTOSO.COM",
                    PasswordHash = "AQAAAAEAACcQAAAAEGDRwe0zHsTj3QyMAki47rONlDW53IiYXvlyp8+gIKjkggsO2aAkFe2I6I2RQrqCAg==",
                    SecurityStamp = "7F2WDYGK6UPHAH72CXNOVLYLVTKZDTE3",
                    ConcurrencyStamp = "df620658-5077-4ee8-b813-e4dc6d4f2196"
                };
            }
        }


        public static User GetUser
        {
            get
            {
                var user = new User("as", "t", "b00629e1-5729-49df-901c-563d22b7637d", "ast");
                user.AddRefreshToken("4NIpI0b7hEMSl+4cpAV2Zh/dKNlY0AGANjuDoN1/8oE=", 1, "127.0.0.1");
                return user;
            }
        }
    }
}
