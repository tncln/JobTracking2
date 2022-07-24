using JobTracking.Web.Constraints;
using JobTracking.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobTracking.Web
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
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseCustomStaticFile();
            app.UseRouting();
            //Hata Sayfasý yönetimi 
            app.UseStatusCodePagesWithReExecute("/Home/PageError", "?code={0}");
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //Area þema
                //endpoints.MapControllerRoute(
                //    name:"areaAdmin",
                //    areaName:"Admin",
                //    pattern:"{area}/{controller}/{action}"
                //    );
                endpoints.MapControllerRoute(
                    name:"areas",
                    pattern:"{area}/{controller=Home}/{action=Index}/{id?}"
                    );


                //csharp, java haricinde kabul etmek istemiyorsak constraint ile kýsýtlýyoruz. 
                endpoints.MapControllerRoute(
                    name:"programlamaRoute",
                    pattern: "programlama/{dil}",
                    defaults:new {controller="Home",action="Index" },
                    constraints: new {dil=new Programlama()}
                    );
                endpoints.MapControllerRoute(
                    name: "kisi",
                    pattern: "kisiler",
                    defaults:new {controller="Home",action="Index"}
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}"
                    );
            });
        }
    }
}
