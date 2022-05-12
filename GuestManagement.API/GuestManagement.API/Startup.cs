using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using GuestManagement.Infrastructure.Configuration;
using GuestManagement.API.Modules;
using GuestManagement.API.Middleware;
using RestaurantGuide.Guests;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using GuestManagement.Infrastructure.Guests;
using GuestManagement.Infrastructure.Services;
using GuestManagement.Infrastructure.Services.Events;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using GuestManagement.API.ValueProviders;
using OpenTelemetry.Trace;
using OpenTelemetry.Resources;
using OpenTelemetry.Exporter;

namespace GuestManagement.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public static Features ApplicationFeatures { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            ApplicationFeatures = configuration.GetSection("Features").Get<Features>();
        }
        public void ConfigureServices(IServiceCollection services)
        {

            string sqlServerLocation = Environment.GetEnvironmentVariable("MySQL_Server", EnvironmentVariableTarget.Process);

            string serviceName = configuration["Monitoring:ServiceName"];
            string serviceVersion = configuration["Monitoring:ServiceVersion"];
            string oTelCollectorEndpoint = configuration["Monitoring:OTelCollectorEndpoint"];

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            services.AddOpenTelemetryTracing(config =>
            {
                config.AddConsoleExporter()
                .AddOtlpExporter(opt =>
                {
                    opt.Endpoint = new Uri(oTelCollectorEndpoint);
                    opt.Protocol = OtlpExportProtocol.Grpc;
                })
                .AddSource()
                .SetResourceBuilder(ResourceBuilder.CreateDefault()
                    .AddService(serviceName: serviceName,
                    serviceVersion: serviceVersion))
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation();

            });
            services.AddControllers(
                options =>
                {
                    var currentRouteValueProvider = options.ValueProviderFactories.IndexOf(
                        options.ValueProviderFactories.OfType<RouteValueProviderFactory>().Single());
                    options.ValueProviderFactories[currentRouteValueProvider] = new TrimmedParametersValueProvider();
                }
            )
                .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling
                     = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                     options.SerializerSettings.Converters.Add(new DateTimeConverter());

                 })
                 .AddMvcOptions(options =>
                 {
                     options.ReturnHttpNotAcceptable = true;
                 })
                 ;

            services.ConfigureDbs(configuration,
            LoggerFactory.Create(x => x.AddConsole()).CreateLogger<GuestDbContext>());

            services.AddSwaggerGen();

            if (ApplicationFeatures.AzureOptions.Enabled)
            {
                services.AddHostedService<LogsService>();
                services.AddHostedService<EventService>();
            }
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new AutomapperModule());
            builder.RegisterModule(new InfrastructureModule(configuration, LoggerFactory
            .Create(x => x.AddConsole()).CreateLogger<InfrastructureModule>()));

            builder.RegisterModule(new DomainModule());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseMiddleware<HttpRequestLogginMiddleware>();

            app.UseSwagger();

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRequestLocalization(new string[] { "pl-PL" });

            app.UseRouting();

            app.UseEndpoints(configure =>
            {
                configure.MapControllers();

            });
        }
    }
}
