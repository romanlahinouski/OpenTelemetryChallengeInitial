using GuestManagement.Domain.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuestManagement.Domain.Guests;
using Microsoft.Extensions.Logging;

namespace GuestManagement.API.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionHandler> logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            this.next = next;
            this.logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
               await next.Invoke(context);               
            }                          
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";

                logger.LogError(ex.Message);
            
                switch (ex)
                {
                 
                    case BusinessRuleValidationException validationException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        context.Response.ContentType = "application/json";                      
                        await context.Response.WriteAsync
                            (validationException.Message);                   
                        break;
                    case FormatException formatException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync(formatException.Message);
                        break;
                    case NoGuestPresentInTheSystemException noGuestException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                           context.Response.ContentType = "application/json";  
                           await context.Response.WriteAsync(noGuestException.Message);
                           break;
                    default:
                        break;
                }
            }
         
        }
    
    }
}
