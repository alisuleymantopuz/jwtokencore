using Autofac;
using jwtokencore.Api.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace jwtokencore.Api.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterUserProcessor>().As<IRegisterUserProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<LoginProcessor>().As<ILoginProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<ExchangeRefreshTokenProcessor>().As<IExchangeRefreshTokenProcessor>().InstancePerLifetimeScope();
        }
    }
}
