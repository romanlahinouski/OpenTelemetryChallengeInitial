using Autofac;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Gateway.Guests;
using Gateway.Modules;
using Gateway.API.Middleware;
using FluentValidation.AspNetCore;
using System.Reflection;
using Gateway.Infrastructure.Users;
using Gateway.Infrastructure.Configuration;
using Gateway.API.Configuration;


namespace Gateway
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        private readonly AppConfig appConfig;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            ILoggerFactory loggerFactory
              = LoggerFactory.Create(builder => { builder.AddConsole(); });

    
            var guestManagementServiceUrl = new Uri(configuration["ConnectionStrings:GuestManagementService"]);

            services.AddHttpContextAccessor();
 
            services.ConfigureTelemetry(configuration);

            services.AddControllers(
                options =>
                {
                    // options.ModelBinderProviders.Insert(0, new RestaurantQueryDtoBinderProvider());
                    //options.InputFormatters.Add(new DateOfBirthFormatter());

                }).AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new DateTimeConverter());

                }).AddFluentValidation(config =>
                 config.RegisterValidatorsFromAssemblies(new Assembly[] { typeof(Startup).Assembly })); ;



            services.AddSwaggerGen();

            services.ConfigureDbs(configuration,
            LoggerFactory.Create(x => x.AddConsole()).CreateLogger<UsersDbContext>());

        }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this.env = env;
            appConfig = new AppConfig(configuration);
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new AutomapperModule());
            builder.RegisterModule(new ApplicationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseMiddleware<HttpRequestLogginMiddleware>();

            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseRequestLocalization(new string[] { "en-US" });

            app.UseRouting();

      
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "/",
                   defaults: new { controller = "Default", action = "Swagger" }
               );

                endpoints.MapControllers();
            });


        }
    }
}
