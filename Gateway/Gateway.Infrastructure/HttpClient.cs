using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Gateway.Infrastructure
{
    public class HttpClient
    {
        private readonly ILogger<HttpClient> logger;

        public static System.Net.Http.HttpClient Instance { get; private set; }


        public HttpClient(Func<System.Net.Http.HttpClient> configBuilder, ILogger<HttpClient> logger)
        {
            if (Instance == null)
            {
                Instance = configBuilder();
            }

            this.logger = logger;
        }

        public System.Net.Http.HttpClient GetInstance()
        {
            return Instance;
        }

        public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string,string> @params)
        {

            logger.LogDebug($"Going to make request under the {url}");
            


            try
            {
                AddParametersToUrl(ref url, @params);

                var response = await Instance.GetAsync(url);

                await EnsureSuccess(response);

                return response;
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex.Message);

                throw;
            }

        }


        public async Task<HttpResponseMessage> PostAsync(string url, string stringContent)
        {

            logger.LogDebug($"Going to make request under the {url}");

            StringContent content = new StringContent(stringContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await Instance.PostAsync(url, content);

                await EnsureSuccess(response);

                return response;
            }

            catch (HttpRequestException ex)
            {
                throw;
            }
        }

        private async Task EnsureSuccess(HttpResponseMessage response)
        {

            if (!response.IsSuccessStatusCode)
            {
                var responseContentString = await response.Content.ReadAsStringAsync();
                logger.LogError(responseContentString);
                throw new HttpRequestException(responseContentString);
            }
        }

        private void AddParametersToUrl(ref string url, Dictionary<string,string> @params){

            if(@params.Any()){
                 StringBuilder urlBuilder = new StringBuilder(url);
                 urlBuilder.Remove(urlBuilder.Length - 1,1); // remove trailing backslash
                 urlBuilder.Append("?");
                 foreach(var param in @params){
                     urlBuilder.Append($"{param.Key}={param.Value}&");
                 }
                 urlBuilder.Remove(urlBuilder.Length - 1, 1);
                 url = urlBuilder.ToString();
            }
        }
    }
}
