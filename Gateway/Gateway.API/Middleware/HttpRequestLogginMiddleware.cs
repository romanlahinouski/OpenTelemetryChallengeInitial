using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Gateway.API.Middleware
{
    public class HttpRequestLogginMiddleware 
    {
        private readonly RequestDelegate request;
        private readonly ILogger<HttpRequestLogginMiddleware> logger;

        public HttpRequestLogginMiddleware(RequestDelegate request,
        ILogger<HttpRequestLogginMiddleware> logger)
        {
            this.request = request;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context){
            
           if(context.Request.Headers.Any())
            logger.LogDebug(
                JsonConvert.SerializeObject(
                    context.Request.Headers.Select(x => new { x.Value, x.Key})
                    .ToList()));
            

            await request.Invoke(context);

        }
        
    }
}