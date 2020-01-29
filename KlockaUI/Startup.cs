using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MemoryStorage;
using KlockaLib;
using KlockaLib.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KlockaUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            var inMemory = GlobalConfiguration.Configuration.UseMemoryStorage();
            services.AddHangfire(s => s.UseStorage(inMemory));

            services.AddTransient<ConnectionValidatorJob>();
            services.AddTransient<ConnectionValidator>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConnectionValidatorJob job)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            // TODO - Fix cron statement as Cron.MinuteInterval will be removed in upcoming versions
            // TODO - Change to every 5 minutes?
            RecurringJob.AddOrUpdate(() => job.CheckHosts(), Cron.MinuteInterval(1));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
        
            
    }
}
