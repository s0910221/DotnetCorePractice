using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCorePractice.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotnetCorePractice {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

            services.AddTransient<IAppSettings, AppSettings> ();
            services.AddScoped<IAppSettingsScoped, AppSettings> ();
            services.AddSingleton<IAppSettingsSingleton, AppSettings> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
            // app.Use (async (context, next) => {
            //     await context.Response.WriteAsync ("Hello");
            //     await next ();
            //     await context.Response.WriteAsync ("Will");
            // });

            // app.Use (async (context, next) => {
            //     await context.Response.WriteAsync ("Test");
            //     if (context.Request.QueryString.Value != "") {
            //         await next ();
            //     }
            //     await context.Response.WriteAsync ("123");
            // });

            // app.Run (async (context) => {
            //     await context.Response.WriteAsync ("World");
            // });

        }
    }
}