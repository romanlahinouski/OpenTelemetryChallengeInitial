FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 6001


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "RestaurantManagement.API/RestaurantManagement.API.csproj"

RUN dotnet publish "RestaurantManagement.API/RestaurantManagement.API.csproj" -c Release -o /app/

RUN apt-get update 
RUN apt-get install unzip
RUN unzip RestaurantManagement.API/AppDynamics-DotNetCore-linux-x64-20.11.0.zip -d /app/

FROM base AS final
ENV CORECLR_PROFILER={57e1aa68-2229-41aa-9931-a6e93bbc64d8}
ENV CORECLR_ENABLE_PROFILING=1 
ENV CORECLR_PROFILER_PATH=/app/libappdprofiler.so

#AppDynamics controller connection 
ENV APPDYNAMICS_CONTROLLER_HOST_NAME=ip-10-115-22-97.eu-central-1.compute.internal
ENV APPDYNAMICS_CONTROLLER_PORT=8090
ENV APPDYNAMICS_CONTROLLER_SSL_ENABLED=false
ENV APPDYNAMICS_AGENT_ACCOUNT_NAME=customer1
ENV APPDYNAMICS_AGENT_ACCOUNT_ACCESS_KEY=467f1a9e-a73b-46b7-bede-c9caad8bb317
 
# Configure application identity in AppDynamics
ENV APPDYNAMICS_AGENT_APPLICATION_NAME="RestaurantGuide"
ENV APPDYNAMICS_AGENT_TIER_NAME="RestaurantManagement"
ENV APPDYNAMICS_AGENT_REUSE_NODE_NAME=true
ENV APPDYNAMICS_AGENT_REUSE_NODE_NAME_PREFIX="Rm"


WORKDIR /usr/local/share/ca-certificates
RUN openssl req -new -x509 -newkey rsa:2048 -keyout RestaurantManagement.API.key -out RestaurantManagement.API.cer -days 365 -subj /CN=localhost  -passout pass:1111
RUN openssl pkcs12 -export -out /app/RestaurantManagement.API.pfx -inkey RestaurantManagement.API.key -in RestaurantManagement.API.cer -passin pass:1111 -password pass:1111
RUN update-ca-certificates
WORKDIR /app
COPY --from=build /app/ .
ENTRYPOINT ["dotnet", "RestaurantManagement.API.dll"]
