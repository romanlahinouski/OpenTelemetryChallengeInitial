using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement.Infrastructure.Payments;
using RestaurantManagement.Infrastructure.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagement.Infrastructure.Configuration
{
    public static class DbsConfiguration
    {

        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDbContext>(options =>
            {

                options.UseMySql(

                    configuration["ConnectionStrings:RestaurantDb"], ServerVersion.AutoDetect(configuration["ConnectionStrings:RestaurantDb"]));

                //options.UseLoggerFactory(loggerFactory);

            });

            //connectionString, ServerVersion.AutoDetect(connectionString)

            services.AddDbContext<PaymentDbContext>(options =>
            {
                options.UseMySql(

                    configuration["ConnectionStrings:RestaurantDb"], ServerVersion.AutoDetect(configuration["ConnectionStrings:RestaurantDb"]));
            });

        }

    }
}
