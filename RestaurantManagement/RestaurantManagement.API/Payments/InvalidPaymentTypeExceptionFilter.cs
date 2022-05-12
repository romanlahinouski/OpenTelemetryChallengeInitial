using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using RestaurantManagement.Domain.Base;
using RestaurantManagement.Domain.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Payments
{
    public class InvalidPaymentTypeExceptionFilter : ExceptionFilterAttribute
    {

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception is DomainException)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                var paymentTypes = Enum.GetNames(typeof(PaymentType));

                var response = new { 
                    ErrorMessage = context.Exception.Message,
                    AvailablePaymentTypes = paymentTypes 
                
                };
                   
                await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));            
            }                  
        }
    }
}
