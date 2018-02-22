using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lee.AADGroupClaims.Policies;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Lee.AADGroupClaims
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
            services.AddAuthentication(sharedOptions => 
            {
                sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(openIdConnectOptions =>
            {
                openIdConnectOptions.ClientId = "614384ca-9e23-4d00-9aba-eebfd42b7483";
                openIdConnectOptions.ClientSecret = "p4H8PmrGKW8wGKKXjuJtqjE3ld45CONP8pNZUcI41R4=";
                openIdConnectOptions.Authority = "https://login.microsoftonline.com/4d2e09c3-d0cf-4bdb-a78e-fe439a99fb82";
                openIdConnectOptions.ResponseType = OpenIdConnectResponseType.Code;
                openIdConnectOptions.GetClaimsFromUserInfoEndpoint = true;
            }).AddCookie();

            services.AddAuthorization(options =>
            {
               options.AddPolicy(DevelopersAuthorizationPolicy.Name, DevelopersAuthorizationPolicy.Build); 
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
