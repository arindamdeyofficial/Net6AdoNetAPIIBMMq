using Authorisation;
using BusinessModel.Common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace HttpClients
{
    public abstract class BaseHttpClient: IBaseHttpClient
    {
        /// <summary>
        /// For log and exception handling.
        /// </summary>
        private readonly IApiRequestHandler _reqHandler;

        private readonly IUserContext _usrContxt;

        private readonly HttpClient _httpClient;

        public BaseHttpClient(HttpClient httpClient, IApiRequestHandler reqHandler
            , IUserContext usrContxt)
        {
            _httpClient = httpClient;
            _reqHandler = reqHandler;
            _usrContxt = usrContxt;
        }

        /// <summary>
        /// Send request to client and format response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="request"></param>
        /// <param name="methodName"></param>
        /// <param name="reqtype"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ActionResult> SendRequest<T, U>(U request, string methodName, HttpMethod reqtype, string token)
        {
            try
            {
                string url = methodName;
                string contentJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                var actualRequest = new HttpRequestMessage(reqtype, url);
                actualRequest.Content = content;
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.SendAsync(actualRequest);
                object responseData;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    responseData = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return new OkObjectResult(responseData)
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new UnauthorizedObjectResult(await response.Content.ReadAsStringAsync())
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new BadRequestObjectResult(await response.Content.ReadAsStringAsync())
                    {
                        StatusCode = (int)response.StatusCode,
                    };
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new NotFoundObjectResult(await response.Content.ReadAsStringAsync())
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new NoContentResult()
                    {
                    };
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    return new ForbidResult(await response.Content.ReadAsStringAsync())
                    {
                    };
                }
                else if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    return new ConflictObjectResult(await response.Content.ReadAsStringAsync())
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
                else
                {
                    responseData = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
                    return new OkObjectResult(responseData)
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }

            }
            catch (Exception ex)
            {
                _reqHandler.RaiseBusinessException(MethodBase.GetCurrentMethod()?.DeclaringType?.DeclaringType?.Name
                    , MethodBase.GetCurrentMethod().Name,
                    "InputType: " + typeof(U) + " || OutputType: " + typeof(T) + " || Error Message: " + ex.Message);
            }
            return null;
        }
        /// <summary>
        /// Send request to python API and format response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="request"></param>
        /// <param name="methodName"></param>
        /// <param name="reqtype"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ActionResult> SendRequestPython<T, U>(U request, string methodName, HttpMethod reqtype, string token)
        {
            try
            {
                string url = methodName;
                string contentJson = request.ToString();
                var content = new StringContent(contentJson, Encoding.UTF8, "application/json");
                var actualRequest = new HttpRequestMessage(reqtype, url);
                actualRequest.Content = content;
                _httpClient.DefaultRequestHeaders.Clear();

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.SendAsync(actualRequest);
                object responseData;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync();
                    responseData = res?.Result;
                    return new OkObjectResult(responseData)
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return new UnauthorizedObjectResult(await response.Content.ReadAsStringAsync())
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
                else if(response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return new BadRequestObjectResult(await response.Content.ReadAsStringAsync())
                    {
                        StatusCode = (int)response.StatusCode,
                        Value = await response.Content.ReadAsStringAsync()
                    };
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new NotFoundObjectResult(await response.Content.ReadAsStringAsync())
                    {
                        StatusCode = (int)response.StatusCode
                    };
                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new NoContentResult()
                    {
                    };
                }

            }
            catch (Exception ex)
            {
                _reqHandler.RaiseBusinessException(MethodBase.GetCurrentMethod()?.DeclaringType?.DeclaringType?.Name
                    , MethodBase.GetCurrentMethod().Name,
                    "InputType: " + typeof(U) + " || OutputType: " + typeof(T) + " || Error Message: " + ex.Message);
            }
            return null;
        }
    }
}