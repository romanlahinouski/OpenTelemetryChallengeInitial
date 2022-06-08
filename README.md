# Introduction 
This application is the target for OTel instrumentation

# Folder structure

- GuestManagement
- Gateway

both are separate applications running on Asp Net Core 3.1. Each of the applications is multilayer to ease development and maintenance. 

# Build Project
1.	Open the main folder for the project
2.	Run ``` ./RestorePackages.sh ```
3.	Run ``` ./BuildAndRun.sh ```
4.	Allow the application to accept incoming connections

By default, the script builds both services to /tmp/<service name> directory and runs them. 

# Make your changes
  
Changes required for the challenge will be made on the API level, as it's the place where application startup is managed, also serving as the place where we configure packages.
 
GuestManagement API project location:
  - GuestManagement/GuestManagement.API/
 
Gateway API project location:
  - Gateway/Gateway.API/
  
 To add nuget package run this command: 
  
  ``` dotnet add package ``` 
  
 For example, ``` dotnet add package Microsoft.EntityFrameworkCore ```
  
