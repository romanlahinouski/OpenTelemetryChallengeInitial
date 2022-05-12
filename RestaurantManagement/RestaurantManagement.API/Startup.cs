using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement.Infrastructure.Restaurants;
using RestaurantGuide.Modules;
using Autofac;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Restaurants;
using RestaurantManagement.Infrastructure.Payments;
using System;
using RestaurantManagement.Application.Payments;
using Microsoft.Extensions.Logging;
using RestaurantManagement.API.Middleware;
using RestaurantManagement.API.Interceptors;
using RestaurantManagement.Infrastructure.Configuration;

namespace RestaurantManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddGrpc(options
                => options.Interceptors.Add<GlobalExceptionInterceptor>());

            services.AddMvcCore()                    
                .AddApiExplorer()
                //.AddAuthorization()
                //.AddCors()
                //.AddDataAnnotations()
                //.AddFormatterMappings()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;                 
                });


            //     ILoggerFactory loggerFactory
            //= LoggerFactory.Create(builder => { builder.AddConsole(); });

            services.ConfigureDb(Configuration);


            services.AddSwaggerGen();
        }

        public void ConfigureContainer(ContainerBuilder builder)      
        {
            builder.RegisterModule(new AdministrationModule());
            builder.RegisterModule(new AutomapperModule());
            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new MediatorModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<GlobalExceptionHandler>();
            
            app.UseSwagger();
           
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.

            app.UseRequestLocalization(new string[] { "pl-PL" });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();              
            }

         
            app.UseHttpsRedirection();

            app.UseRouting();
         

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<GuestRegistrationGRPCService>();
            });
        }
    }
}
