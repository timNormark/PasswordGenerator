using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordGenerator.Core;
using PasswordGenerator.Core.Repositories.PasswordLog;
using PasswordGenerator.Core.Services.GeneratePasswordService;
using PasswordGenerator.Core.Services.GeneratePasswordService.Models;
using PasswordGenerator.Core.Services.GeneratePasswordService.PasswordGenerators;
using PasswordGenerator.Core.Services.LogPasswordService;
using PasswordGenerator.Infrastructure.Repositories;

namespace PasswordGenerator.Web
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
            services.AddControllersWithViews();

            var appSettings = new PasswordGeneratorSettings();
            Configuration.Bind("PasswordGeneratorSettings", appSettings);
            services.AddSingleton(appSettings);

            services.AddScoped<Func<PersonServiceModel, IPasswordGenerator>>(_ =>
            {
                return p =>
                {
                    return p switch
                    {
                        TeacherServiceModel t => new TeacherPasswordGenerator(),
                        StudentServiceModel s when s.SchoolYear >= 1 && s.SchoolYear <= 3 => new StudentYear1To3PasswordGenerator(appSettings),
                        StudentServiceModel s when s.SchoolYear >= 4 && s.SchoolYear <= 6 => new StudentYear4To6PasswordGenerator(),
                        _ => null,
                    };
                };
            });

            services.AddScoped<IGeneratePasswordService, GeneratePasswordService>();
            services.AddScoped<ILogPasswordService, LogPasswordService>();
            services.AddScoped<IPasswordLogRepository, PasswordLogRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
