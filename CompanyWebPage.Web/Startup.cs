using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebPage.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompanyWebPage.Web
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
            services.AddScoped<IActionLogger, CompanyWebPage.Web.Logic.FakeActionLogger>();

            services.AddMvc();

            services.AddMvc()
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
               .AddDataAnnotationsLocalization();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            var cultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("es-ES")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                    options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;

            });

            services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options =>
            {
                options.ConstraintMap.Add("culture", typeof(QueryStringRequestCultureProvider));
            });
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Error");

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            var options = app.ApplicationServices.GetService<Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "about",
                  pattern: "/about",
                  defaults: new { controller = "Home", action = "Index" });
            });

            //Routing for newsleter
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "newsletter",
                  pattern: "/newsletter",
                  defaults: new { controller = "Newsletter", action = "Subscribe" });
            });

            //Routing for invalid requests
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "newsletter",
                  pattern: "{*any}",
                  defaults: new { controller = "Home", action = "Error" });
            });
        }
    }
}
