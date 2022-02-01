using Authorisation;
using BusinessModel.Common;
using Microsoft.AspNetCore.Mvc;

namespace HttpClients
{
    /// <summary>
    /// ConfigClient
    /// </summary>
    public class ConfigClient : BaseHttpClient, IConfigClient
    {
        /// <summary>
        /// Token Service to call token
        /// </summary>
        private readonly ITokenService _tokenService;

        /// <summary>
        /// GeographyClient constructor
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="reqHandler"></param>
        /// <param name="usrContext"></param>
        /// <param name="tokenService"></param>
        /// <param name="tokenNotificationService"></param>
        public ConfigClient(HttpClient httpClient, IApiRequestHandler reqHandler
            , IUserContext usrContext, ITokenService tokenService, ITokenNotificationService tokenNotificationService)
            : base(httpClient, reqHandler, usrContext)
        {
            _tokenService = tokenService;
        }
        /// <summary>
        /// SendRequestConfig
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="request"></param>
        /// <param name="methodName"></param>
        /// <param name="reqtype"></param>
        /// <returns></returns>
        public async Task<ActionResult> SendRequestConfig<T, U>(U request, string methodName, HttpMethod reqtype)
        {
            var token = await _tokenService.GetTokenforConfigApplication();
            return await SendRequest<T, U>(request, "/api/Config/" + methodName, reqtype, await _tokenService.GetTokenforConfigApplication());
        }
    }
}
