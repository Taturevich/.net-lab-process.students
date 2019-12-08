// <copyright file="AppModule.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.App_Start
{
    using Autofac;

    using TestWebApp.Services;

    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbEventService>().As<IEventService>();
        }
    }
}