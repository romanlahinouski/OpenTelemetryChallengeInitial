# Introduction 
This application is target for OTel instumentation

# Folder structure

- GuestManagement
- Gateway

both are separate application running on Asp Net Core 3.1. Each of the applications is multilayer to ease development and maintence. 

# Build Project
1.	Open main folder for the project
2.	Run ./BuildAndRun.sh

By default script builds both services to /tmp/<service name> directory and runs them. 

# Make your changes
  
Changes required for the challenge will be made on the API level, as it's the place where application startup is managed, also serving as the place where we configure packages.
 
GuestManagement API project location:
  - GuestManagement/GuestManagement.API/
 
Gateway API project location:
  - Gateway/Gateway.API/
  
 To add nuget package run this command: 
  
  dotnet add package. 
  
 For example: dotnet add package Microsoft.EntityFrameworkCore
  
 Then run ./RebuildAndRun.sh
