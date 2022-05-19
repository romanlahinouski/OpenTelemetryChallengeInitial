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
