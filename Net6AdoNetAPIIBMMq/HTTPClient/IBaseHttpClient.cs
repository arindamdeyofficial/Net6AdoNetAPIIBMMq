using Microsoft.AspNetCore.Mvc;

namespace HttpClients
{
    public interface IBaseHttpClient
    {
        Task<ActionResult> SendRequest<T, U>(U request, string methodName, HttpMethod reqtype, string token);
    }
}

