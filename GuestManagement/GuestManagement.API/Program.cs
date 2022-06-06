using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NLog.Web;


namespace GuestManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {             
                CreateHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }


#warning copy of the context data from main thread to helper threads is disabled
            ExecutionContext.SuppressFlow();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())               
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                
                })   
                .ConfigureLogging(options =>
                {
                    options.ClearProviders();

                }).UseNLog();
    }
}


