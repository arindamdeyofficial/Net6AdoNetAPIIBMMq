using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using BusinessModel.Common;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients
{
    /// <summary>
    /// EmailClient
    /// </summary>
    public class EmailClient : IEmailClient
    {
        private readonly IHttpClientFactory _clientFactory;

        private readonly IConfiguration _configuration;

        /// <summary>
        /// EmailClient
        /// </summary>
        /// <param name="clientFactory"></param>
        /// <param name="configuration"></param>
        public EmailClient(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<string> SendNotificationEmailOnFailure()
        {
            var msgJson = "";
             var content = new StringContent(msgJson, Encoding.UTF8, "application/json");
             var request = new HttpRequestMessage(HttpMethod.Post, _configuration["NotificationLogicAppUrl"]);
            request.Content = content;
             var client = _clientFactory.CreateClient("NotificationEmail");
             var response = await client.SendAsync(request);
             if (response.IsSuccessStatusCode)
                {
                    return response.ReasonPhrase;
                }
             else
                {
                    return "fail";
                }
        }
    }
}
