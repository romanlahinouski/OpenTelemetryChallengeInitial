using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Filters
{
    public class TestFilter : Attribute,IAuthorizationFilter
    {
        private readonly IWebHostEnvironment env;

        public TestFilter(IWebHostEnvironment env)
        {
            this.env = env;
        }

         public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (env.IsDevelopment())
            {
                context.Result = new StatusCodeResult(404);
            }
        }
    }
}
