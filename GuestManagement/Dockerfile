FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY . .
#RUN dotnet restore "GuestManagement.API/GuestManagement.API.csproj"
RUN dotnet publish "GuestManagement.API/GuestManagement.API.csproj" -c Release -o /app/

RUN apt-get update 
RUN apt-get install unzip
RUN unzip GuestManagement.API/AppDynamics-DotNetCore-linux-x64-21.8.0.zip -d /app/


FROM base AS final

ENV ASPNETCORE_Kestrel__Certificates__Default__Password="1111"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/GuestManagement.API.pfx
ENV ASPNETCORE_ENVIRONMENT="Production"

#WORKDIR /usr/local/share/ca-certificates
#RUN openssl req -new -x509 -newkey rsa:2048 -keyout GuestManagement.API.key -out GuestManagement.API.cer -days 365 -subj /CN=localhost  -passout pass:1111
#RUN openssl pkcs12 -export -out /app/GuestManagement.API.pfx -inkey GuestManagement.API.key -in GuestManagement.API.cer -passin pass:1111 -password pass:1111
#RUN update-ca-certificates
RUN openssl req -new -x509 -newkey rsa:2048 -keyout /etc/ssl/certs/GuestManagement.API.pem -out GuestManagement.API.crt -days 365 -subj /CN=localhost  -passout pass:1111
RUN openssl pkcs12 -export -out /app/GuestManagement.API.pfx -inkey /etc/ssl/certs/GuestManagement.API.pem -in GuestManagement.API.crt -passin pass:1111 -password pass:1111
RUN update-ca-certificates

WORKDIR /app
COPY --from=build /src/GuestManagement.p12/ .
COPY --from=build /app/ .
ENTRYPOINT ["dotnet", "GuestManagement.API.dll"]
