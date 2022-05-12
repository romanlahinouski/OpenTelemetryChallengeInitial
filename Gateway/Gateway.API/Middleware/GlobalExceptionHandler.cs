using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.API.Middleware
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
            catch (HttpRequestException ex){
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.Body.WriteAsync(UTF32Encoding.UTF32.GetBytes(ex.Message));
                logger.LogError(ex.Message);
            }
            
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);                              
            }
         
        }
    
    }
}
