using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using BusinessLayer.Impl;
using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Entities.CommonEntities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SASFW.Controllers;

namespace SASFW
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
        {// change the default migrations assembly

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EFDBContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("DataLayer")));

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddTransient<ICustumRepository<User>, EFCustumRepository<User>>();
            services.AddTransient<ICustumRepository<Directory>, EFCustumRepository<Directory>>();
            services.AddTransient<ICustumRepository<Material>, EFCustumRepository<Material>>();
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
                app.UseBrowserLink();
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
