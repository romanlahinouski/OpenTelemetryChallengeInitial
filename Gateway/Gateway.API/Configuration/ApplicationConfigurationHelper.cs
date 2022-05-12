
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Gateway.Infrastructure.Configuration;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Gateway.API.Configuration
{
    public static class ApplicationConfigurationHelper
    {

        public static void ConfigureSecurity(this IServiceCollection services,
        IConfiguration configuration)
        {
            var identityConfiguration = AppConfig.GetAzureOptions().IdentityConfiguration;

            if (identityConfiguration.IsEnabled)
            {
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(jwtBearerOptions => { }
                , identityOptions =>
                {
                    identityOptions.ClientId = identityConfiguration.ClientId;
                    identityOptions.TenantId = identityConfiguration.TenantId;
                    identityOptions.Instance = identityConfiguration.Instance;
                    identityOptions.Domain = identityConfiguration.Domain;
                    identityOptions.Events.OnTokenValidated = async context =>
                    {
                        //Calls method to process groups overage claim.
                        var overageGroupClaims = await GraphHelper.GetSignedInUsersGroups(context);
                    };
                }, subscribeToJwtBearerMiddlewareDiagnosticsEvents: true);

                services.AddAuthorization(options =>
            {
                options.AddPolicy("GroupAdmins", policy =>
                {
                    policy.Requirements.Add(new GroupPolicyRequirenment(new Group("Admin", "3acc3903-2384-421e-807c-14907f127cca")));
                });

                options.AddPolicy("GroupUsers", policy =>
              {
                  policy.Requirements.Add(new GroupPolicyRequirenment(new Group("Users", "3acc3903-2384-421e-807c-14907f127cca")));
              });

            });
            }
            else
            {

                var apiScopes = new List<Scope> {
                new Scope ("Guests"),
                new Scope("Payments")

                };

                var identityResources = new List<IdentityResource> {
              new  IdentityResources.OpenId(),
            new IdentityResources.Profile()
            };

                var apiResources = new List<ApiResource>(){
                new ApiResource("Guests", "GusetAPI")
                {   Scopes = apiScopes  },
            };

                var secret = new Secret("1111".Sha256());

                var clients = new List<Client> {

                new Client{
                    ClientId = "12345",
                    ClientName = "All",
                    ClientSecrets = new List<Secret>() {secret},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"Guests"}

            }};

                var rsaKey = new RsaSecurityKey(RSA.Create(2048));


                services.AddIdentityServer()
                .AddInMemoryIdentityResources(identityResources)
                .AddInMemoryApiResources(apiResources)
                .AddInMemoryClients(clients)
                .AddJwtBearerClientAuthentication()
                .AddSigningCredential(new SigningCredentials(rsaKey, "RS256"));


                services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
                 {
                     options.Authority = $"{configuration["Kestrel:Endpoints:Https:Url"]}/";

                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateAudience = false
                     };

                 });

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("ApiScope", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("scope", "Guests");

                    });

                });

            }

        }

        public static void ConfigureTelemetry(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
           
            string serviceName = configuration["Monitoring:ServiceName"];
            string serviceVersion = configuration["Monitoring:ServiceVersion"];
            string otlpEndpoint = configuration["Monitoring:OTelCollectorEndpoint"];

            services.AddOpenTelemetryTracing(
                traceBuilder =>
                {
                    traceBuilder.AddConsoleExporter();
                    traceBuilder.AddOtlpExporter( builder =>{
                        builder.Endpoint = new Uri(otlpEndpoint);
                        builder.Protocol = OtlpExportProtocol.Grpc;
                    });
                    
                    traceBuilder.SetResourceBuilder(ResourceBuilder.CreateDefault()
                    .AddService(serviceName,serviceVersion: serviceVersion));
                    //traceBuilder.AddSource(serviceName);

                    traceBuilder.AddHttpClientInstrumentation();
                    traceBuilder.AddAspNetCoreInstrumentation();
                }
            );
        }


    }
}

