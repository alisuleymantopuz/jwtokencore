using Microsoft.EntityFrameworkCore;
using jwtokencore.Api.Core.Shared.Context;

namespace jwtokencore.Api.Infrastructure.Data
{
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
    {
        protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
        {
            return new AppDbContext(options);
        }
    }
}
