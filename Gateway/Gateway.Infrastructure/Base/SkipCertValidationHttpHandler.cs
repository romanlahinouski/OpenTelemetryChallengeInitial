using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Gateway.Infrastructure.Base
{
    public  class SkipCertValidationHttpHandler : HttpClientHandler
    {
        private readonly IConfiguration configuration;

        public SkipCertValidationHttpHandler(IConfiguration configuration)
        {
            this.configuration = configuration;

            var handler = new HttpClientHandler();
            var skipValidationURLs = configuration["SkipCertificatesValidationForThisURLs"].Split(";");

            base.ServerCertificateCustomValidationCallback =
                ((sender, cert, chain, errors)
                => HttpClientExtensions.ValidateCert(skipValidationURLs, sender, cert, chain, errors));         
        }

               
    }
}
