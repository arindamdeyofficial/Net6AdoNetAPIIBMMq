using Authorisation;
using BusinessModel.Common;
using BusinessModel.Config;
using HttpClients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ConfigService.Consume
{
    public class CustomConfigService : BaseHttpClient, ICustomConfigService
    {
        /// <summary>
        /// For log and exception handling.
        /// </summary>
        private readonly IApiRequestHandler _reqHandler;

        /// <summary>
        /// IHttpContextAccessor
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// httpclient
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// injecting usercontext
        /// </summary>
        private readonly IUserContext _usrContxt;

      

        /// <summary>
        /// azure ad token for authentication to calling web api
        /// </summary>
        public string _token;

        public CustomConfigService(HttpClient httpClient, IApiRequestHandler reqHandler
            , IHttpContextAccessor httpContextAccessor, IUserContext usrContxt)
            : base(httpClient, reqHandler, usrContxt)
        {
            _httpClient = httpClient;
            _reqHandler = reqHandler;
            _httpContextAccessor = httpContextAccessor;
            _usrContxt = usrContxt;
            _token = usrContxt.GenerateTokenConfigServiceApplication();
        }

        /// <summary>
        /// Reads config
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<ConfigModel>> ReadConfig()
        {
            ActionResult<ConfigModel> res = new ConfigModel();
            try
            {
                res = await SendRequest<ConfigModel, ConfigModel>(new ConfigModel { ApplicationId = "a" }
                , "GetAzureConfig", HttpMethod.Post
                , _usrContxt.GenerateTokenConfigServiceApplication());
            }
            catch (Exception ex)
            {
                _reqHandler.RaiseBusinessException(MethodBase.GetCurrentMethod()?.DeclaringType?.DeclaringType?.Name
                    , MethodBase.GetCurrentMethod().Name,
                    "Error Message: " + ex.Message);
            }
            return res;
        }
    }
}
