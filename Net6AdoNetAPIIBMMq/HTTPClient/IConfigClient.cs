using Microsoft.AspNetCore.Mvc;

namespace HttpClients
{
    /// <summary>
    /// IConfigClient
    /// </summary>
    public interface IConfigClient
    {
        /// <summary>
        /// SendRequestConfig
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="request"></param>
        /// <param name="methodName"></param>
        /// <param name="reqtype"></param>
        /// <returns></returns>
        Task<ActionResult> SendRequestConfig<T, U>(U request, string methodName, HttpMethod reqtype);
    }
}
