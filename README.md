# Introduction 
This application is the target for OTel instrumentation

# Folder structure

- GuestManagement
- Gateway

both are separate applications running on Asp Net Core 3.1. Each of the applications is multilayer to ease development and maintenance. 

# Build Project
1.	Open the main folder for the project
2.	Run ./BuildAndRun.sh
3.	Allow the application to accept incoming connections

By default, the script builds both services to /tmp/<service name> directory and runs them. 
