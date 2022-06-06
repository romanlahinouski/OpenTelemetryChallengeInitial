using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GuestManagement.Infrastructure
{
   public static class HttpClientExtensions
    {

        public static bool ValidateCert(
            string [] skipURLs,
            object sender, 
            X509Certificate cert, 
            X509Chain chain, 
            SslPolicyErrors errors)
        {         
            var serverName = cert.Subject.ToLower();
            if (skipURLs.Any(overrideName => serverName.Contains(overrideName))) return true;

            // otherwise use the standard validation results
            return errors == SslPolicyErrors.None;
        }
    }
}
