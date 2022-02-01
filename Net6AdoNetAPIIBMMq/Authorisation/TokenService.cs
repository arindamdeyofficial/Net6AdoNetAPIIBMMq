using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authorisation
{
    public class TokenService : ITokenService
    {
        private readonly ITokenAcquisition _tokenAcquisition;

        private readonly IConfiguration _configuration;

        public TokenService(ITokenAcquisition tokenAcquisition,
            IConfiguration configuration)
        {
            _tokenAcquisition = tokenAcquisition;
            _configuration = configuration;
        }

        public async Task<string> GetTokenforConfigApplication()
        {
            return await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { _configuration["DownStreamConfigAPI:ScopeForAccessToken"] }).ConfigureAwait(false);
        }
    }
}
