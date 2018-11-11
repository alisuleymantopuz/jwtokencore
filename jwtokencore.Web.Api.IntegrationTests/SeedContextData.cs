using jwtokencore.Api.Core.Authentication;
using jwtokencore.Api.Infrastructure.Data;
using jwtokencore.Api.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Web.Api.IntegrationTests
{
    public class SeedContextData
    {
        public static void PopulateTestData(AppIdentityDbContext dbContext)
        {
            dbContext.Users.Add(FakeData.GetAppUser);
            dbContext.SaveChanges();
        }

        public static void PopulateTestData(AppDbContext dbContext)
        {
            var user = FakeData.GetUser;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }
    }
}
