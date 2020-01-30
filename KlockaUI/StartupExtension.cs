using Hangfire;
using KlockaLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlockaUI
{
    public static class StartupExtension
    {
        public static void AddHangfireJobs(this IApplicationBuilder app)
        {
            var job = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ConnectionValidatorJob>();
            RecurringJob.AddOrUpdate(() => job.CheckHosts(), "*/5 * * * *");
        }
    }
}
