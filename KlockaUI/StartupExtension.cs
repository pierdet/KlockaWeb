using Hangfire;
using KlockaLib;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlockaUI
{
    public static class StartupExtension
    {
        public static void AddHangfireJobs(this IApplicationBuilder app, ConnectionValidatorJob job)
        {
            RecurringJob.AddOrUpdate(() => job.CheckHosts(), "*/5 * * * *");
        }
    }
}
