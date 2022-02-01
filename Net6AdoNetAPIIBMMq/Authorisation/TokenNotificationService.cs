using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorisation
{
    public class TokenNotificationService : ITokenNotificationService
    {

        private readonly IConfiguration _configuration;
        public TokenNotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GetToken()
        {
            try
            {
                IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(_configuration["NotificationEngine:ClientId"])
                    .WithClientSecret(_configuration["NotificationEngine:ClientSecret"])
                    .WithAuthority(new Uri(_configuration["NotificationEngine:Authority"]))
                    .Build();
                var result = await app.AcquireTokenForClient(new[] { _configuration["NotificationEngine:Scopes"] }).ExecuteAsync();
                return result.AccessToken;
            }
            catch
            {
                return null;
            }
        }
    }
}
