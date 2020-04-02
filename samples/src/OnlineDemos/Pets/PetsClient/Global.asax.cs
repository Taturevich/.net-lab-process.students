using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.Wcf;
using PetsClient.ServiceReference1;

namespace PetsClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();
            builder
                .Register(c => new ChannelFactory<IPetService>(
                    new WSHttpBinding(),
                    new EndpointAddress("http://localhost:61897/PetService.svc")))
                .SingleInstance();
            builder
                .Register(context =>
                {
                    var client = new PetServiceClient();
                    if (client.ClientCredentials != null)
                    {
                        client.ClientCredentials.UserName.UserName = "jwtTokenFromUserApi";
                    }
                    return client;
                })
                .As<IPetService>()
                .UseWcfSafeRelease();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
