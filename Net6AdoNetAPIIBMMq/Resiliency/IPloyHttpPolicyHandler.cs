using Polly;
using System.Net.Http;

namespace Resiliency
{
    public interface IPloyHttpPolicyHandler
    {
        IAsyncPolicy<HttpResponseMessage> GetRetryPolicy();
        IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy();
        IAsyncPolicy<HttpResponseMessage> GetHttpFallbackPolicy();
    }
}
