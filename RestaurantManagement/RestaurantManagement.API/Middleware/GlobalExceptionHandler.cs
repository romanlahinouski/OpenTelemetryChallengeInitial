using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.API.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            this.next = next;
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

                switch (ex)
                {
                    case ApplicationException applicationException:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync(applicationException.Message);
                        break;
                    default:
                        break;
                }
            }

        }

    }
}
