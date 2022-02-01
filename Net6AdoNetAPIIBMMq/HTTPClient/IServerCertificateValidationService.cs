using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace HttpClients
{
    public interface IServerCertificateValidationService
    {
        public bool Validate(HttpRequestMessage sender, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors errors);
    }
}
