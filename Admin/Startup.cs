using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models;
using BusinessLayer;
using BusinessLayer.Impl;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Entities.CommonEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Admin
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFDBContext>(options => options.UseSqlServer(connection));


            services.AddTransient<ICustumRepository<User>, EFCustumRepository<User>>();
            services.AddTransient<ICustumRepository<Directory>, EFCustumRepository<Directory>>();
            services.AddTransient<ICustumRepository<SiteWebPage>, EFCustumRepository<SiteWebPage>>();
            services.AddTransient<ICustumRepository<CustumContent>, EFCustumRepository<CustumContent>>();
            services.AddTransient<ICustumRepository<CustumField>, EFCustumRepository<CustumField>>();
            services.AddTransient<ICustumRepository<CustumFieldValue>, EFCustumRepository<CustumFieldValue>>();
            services.AddScoped<DataManager>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // добавляем сборку через webpack
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }

           
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
