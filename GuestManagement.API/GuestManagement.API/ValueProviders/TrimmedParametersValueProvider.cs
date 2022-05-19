using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Primitives;

namespace GuestManagement.API.ValueProviders
{
    public class TrimmedParametersValueProvider : IValueProviderFactory
    {
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
        {
           
           if(context == null)
            throw new ArgumentNullException(nameof(context));
     
            var routeValues = context.ActionContext.HttpContext.Request.RouteValues;

            if(routeValues?.Count > 0)
            {
            foreach(var value in routeValues ){

                string trimmedValue = value.Value.ToString().Trim();
         
                context.ActionContext.HttpContext.Request.RouteValues[value.Key] 
                = trimmedValue;

            }
            context.ValueProviders.Add(new RouteValueProvider(BindingSource.Path,context.ActionContext.HttpContext.Request.RouteValues));
            }

              return Task.CompletedTask;
        }
    }
}

