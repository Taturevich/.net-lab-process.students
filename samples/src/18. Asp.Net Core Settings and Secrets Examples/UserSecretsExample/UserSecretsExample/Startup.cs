using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserSecretsExample
{
    public class Startup
    {
        /// <summary>
        /// The root configuration.
        /// </summary>
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddUserSecrets<Startup>()
                .Build();

            // Now you have access to your secrets from IConfigurationRoot object. You can use it during configuration phase or save it in option file
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // adding web service pipeline
            services.Configure<OptionsWithSecrets>(binder =>
            {
                binder.FirstSecret = _configuration[nameof(OptionsWithSecrets.FirstSecret)];
                binder.SecondSecret = _configuration[nameof(OptionsWithSecrets.SecondSecret)];
            }); // register secrets in the setting object
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "",
                    new { controller = "Secret", action = "Index" });
            });
        }
    }
}
