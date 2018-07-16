using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FRAlexaApp.Services.Helpers
{
    public static class CertificateHelper
    {
        internal static HttpClientHandler OBClientHandler()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var handler = new HttpClientHandler();
            var certificate = new X509Certificate2Collection(); // load proper network certificates
            handler.ClientCertificates.AddRange(certificate);
            return handler;
        }
    }
}
