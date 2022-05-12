FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 9001

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Gateway.API/Gateway.API.csproj"

RUN dotnet publish "Gateway.API/Gateway.API.csproj" -c Release -o /app/

RUN apt-get clean
RUN apt-get update 
RUN apt-get install unzip 
RUN unzip Gateway.API/AppDynamics-DotNetCore-linux-x64-21.8.0.zip -d /app/

FROM base AS final
#AppDynamcis agent profiler
ENV CORECLR_PROFILER={57e1aa68-2229-41aa-9931-a6e93bbc64d8}
ENV CORECLR_ENABLE_PROFILING=1 
ENV CORECLR_PROFILER_PATH=/app/libappdprofiler.so

#AppDynamics controller connection 
ENV APPDYNAMICS_CONTROLLER_HOST_NAME=rdc.saas.appdynamics.com
ENV APPDYNAMICS_CONTROLLER_PORT=443
ENV APPDYNAMICS_CONTROLLER_SSL_ENABLED=true
ENV APPDYNAMICS_AGENT_ACCOUNT_NAME=rdc
ENV APPDYNAMICS_AGENT_ACCOUNT_ACCESS_KEY=nnischowp23r
 
# Configure application identity in AppDynamics
ENV APPDYNAMICS_AGENT_APPLICATION_NAME="Roman_NetCore"
ENV APPDYNAMICS_AGENT_TIER_NAME="Gateway"
ENV APPDYNAMICS_AGENT_REUSE_NODE_NAME=true
ENV APPDYNAMICS_AGENT_REUSE_NODE_NAME_PREFIX="Gw"

#-e ASPNETCORE_Kestrel__Certificates__Default__Password="password" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="1111"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/Gateway.API.pfx

ENV APPDYNAMICS_ANALYTICS_HOST_NAME: "fra-ana-api.saas.appdynamics.com"
ENV APPDYNAMICS_ANALYTICS_PORT: "443"
ENV APPDYNAMICS_ANALYTICS_SSL_ENABLED: "true"


#RUN openssl pkcs12 -in aspnetapp.pfx -nocerts -out aspnetapp.crt -nodes --password pass:1111
#RUN openssl pkcs12 -in aspnetapp.pfx -nocerts -out aspnetapp.pem -nodes --password pass:1111

RUN openssl req -new -x509 -newkey rsa:2048 -keyout /etc/ssl/certs/Gateway.API.pem -out Gateway.API.crt -days 365 -subj /CN=localhost  -passout pass:1111
RUN openssl pkcs12 -export -out /app/Gateway.API.pfx -inkey /etc/ssl/certs/Gateway.API.pem -in Gateway.API.crt -passin pass:1111 -password pass:1111
RUN update-ca-certificates

WORKDIR /app
COPY --from=build /src/Gateway.p12 .
COPY --from=build /app/ .
ENTRYPOINT ["dotnet", "Gateway.API.dll"]
