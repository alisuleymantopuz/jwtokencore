using Autofac;
using jwtokencore.Api.Core.Authentication;
using jwtokencore.Api.Core.Shared.Contracts.Services;
using jwtokencore.Api.Infrastructure.Auth;
using jwtokencore.Api.Infrastructure.Data.Repositories;
using jwtokencore.Api.Infrastructure.Logging;
using Module = Autofac.Module;

namespace jwtokencore.Api.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<JwtTokenHandler>().As<IJwtTokenHandler>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<TokenFactory>().As<ITokenFactory>().SingleInstance();
            builder.RegisterType<JwtTokenValidator>().As<IJwtTokenValidator>().SingleInstance().FindConstructorsWith(new InternalConstructorFinder());
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
        }
    }
}
