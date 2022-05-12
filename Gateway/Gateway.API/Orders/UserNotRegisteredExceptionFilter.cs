using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.Application.Orders;

namespace Gateway.Orders.Administration
{
    public class UserNotRegisteredExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {

            var ae = context.Exception as AggregateException;

            if (ae != null)
                foreach (var e in ae.Flatten().InnerExceptions)
                {
                    var exec = e as UserNotRegisterForAVisitException;

                    if (exec != null)
                    {
                        var result = new BadRequestObjectResult($"User with id {exec.GuestId} is not register for a visit, please register a guest first");
                        context.Result = result;
                    }
                    else
                    {
                        throw e;
                    }
                }
        }
    }
}
