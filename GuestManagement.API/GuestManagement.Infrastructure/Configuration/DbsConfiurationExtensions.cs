using System;
using GuestManagement.Infrastructure.Guests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GuestManagement.Infrastructure.Configuration
{
    public static class DbsConfiurationExtensions
    {
      
        public static void ConfigureDbs(this IServiceCollection services, IConfiguration configuration, ILogger<GuestDbContext> logger)
        {
            services.AddDbContextPool<GuestDbContext>(builder => {
               string sqlServerLocation = Environment.GetEnvironmentVariable("MySQL_Server", EnvironmentVariableTarget.Process);
               string fullConnString = configuration["ConnectionStrings:GuestDbConnectionString"];
               if(String.IsNullOrEmpty(sqlServerLocation)){
                 fullConnString = "Server=localhost;" + fullConnString;
               }
               else{
                   fullConnString = $"Server={sqlServerLocation};" + fullConnString;
               }
                           
                builder.UseMySql(fullConnString);

                logger.LogInformation($"Connection string is {fullConnString}");
            });


        }
    }
}
