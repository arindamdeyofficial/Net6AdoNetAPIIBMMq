
using BusinessModel.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace HttpClients
{
    public class ServerCertificateCustomValidationService : IServerCertificateValidationService
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _env;

        /// <summary>
        /// For log and exception handling.
        /// </summary>
        private readonly IApiRequestHandler _reqHandler;

        public ServerCertificateCustomValidationService(IConfiguration configuration, IHostEnvironment env, IApiRequestHandler reqHandler)
        {
            _configuration = configuration;
            _env = env;
            _reqHandler = reqHandler;
        }

        public bool Validate(HttpRequestMessage sender, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors errors)
        {
            // for development, trust all certificates.
            if (_env.IsDevelopment())
            {
                _reqHandler.LogInfo("Validate",$"{_env.IsDevelopment()}", "development env");
                return true;
            }

            // The validCertHashStrings contains the hash strings of the X509 certificates we trust.
            // For Notification Engine and PDF Report Service hostname is same therefore both have same server certificate. 
            var validCertHashStrings = GetValidCertHashStrings();
            _reqHandler.LogInfo("Validate", $"{validCertHashStrings}", "development env");
            // trust only some certificates.
            _reqHandler.LogInfo("Validate", $"{ validCertHashStrings.Exists(x => x.ToUpperInvariant() == certificate.GetCertHashString().ToUpperInvariant())}", "development env");
            return validCertHashStrings.Exists(x => x.ToUpperInvariant() == certificate.GetCertHashString().ToUpperInvariant());
        }

        private List<string> GetValidCertHashStrings()
        {
            _reqHandler.LogInfo("Validate", $"{_configuration["NotificationEngine:ValidServerCerts"]}", "development env");
            return JsonSerializer.Deserialize<List<string>>(_configuration["NotificationEngine:ValidServerCerts"]);
        }
    }
}
