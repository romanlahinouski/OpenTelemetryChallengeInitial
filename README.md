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

# Checking the result
  
  In the console from where you have started the script you should be able to see the following output being logged
  
Activity.TraceId:          8c401eb119367613a729198abea26fc3
Activity.SpanId:           e94107fff62cf702
Activity.TraceFlags:           Recorded
Activity.ActivitySourceName: OpenTelemetry.Instrumentation.AspNetCore
Activity.DisplayName: api/Guest
Activity.Kind:        Server
Activity.StartTime:   2022-06-06T07:18:39.5749930Z
Activity.Duration:    00:00:02.6251420
Activity.Tags:
    http.host: localhost:9001
    http.method: POST
    http.target: /api/Guest
    http.url: http://localhost:9001/api/Guest
    http.user_agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.61 Safari/537.36
    http.route: api/Guest
    http.status_code: 201
    StatusCode : UNSET
Resource associated with Activity:
    service.name: GW
    service.version: 1.0.0
    service.instance.id: 63b674d8-4ff4-4205-9322-db0d2f7c0f15
