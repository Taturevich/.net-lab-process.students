using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json;

using Swashbuckle.AspNetCore.Swagger;

using UserCatalogue.Api.Infrastructure;
using UserCatalogue.Api.Stores;

namespace UserCatalogue.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // EF context
            var connectionString = Configuration.GetConnectionString("TicketmanagementDB");
            services.AddDbContext<UserCatalogueContext>(opts =>
            {
                opts.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
            });

            // Identity
            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders();
            services.AddTransient<IUserStore<IdentityUser>, CustomUserRoleStore>();
            services.AddTransient<IUserPasswordStore<IdentityUser>, CustomUserRoleStore>();
            services.AddTransient<IUserRoleStore<IdentityUser>, CustomUserRoleStore>();
            services.AddTransient<IRoleStore<IdentityRole>, CustomRoleStore>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.Formatting = Formatting.Indented;
                    });

            // Add Jwt Authentication
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "User API doc", Version = "v1" });
                    var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");
                    c.IncludeXmlComments(filePath);
                });
            services.AddMvcCore().AddApiExplorer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger(options => { options.RouteTemplate = "docs/{documentName}/swagger.json"; });
            app.UseSwaggerUI(
                options =>
                    {
                        options.RoutePrefix = "docs";
                        options.DocumentTitle = "User API documentation";
                        options.SwaggerEndpoint("/docs/v1/swagger.json", "User API documentation V1");
                    });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<UserCatalogueContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
