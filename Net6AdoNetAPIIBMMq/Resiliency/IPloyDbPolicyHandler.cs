using Polly.Bulkhead;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.Retry;
using Polly.Timeout;
using Polly.Wrap;

namespace Resiliency
{
    public interface IPolyDbPolicyHandler
    {
        AsyncPolicyWrap GetPollyPolicyConfiguration();
        AsyncFallbackPolicy GetDbFallbackPolicy();
        AsyncBulkheadPolicy GetDbBulkheadPolicy();
        AsyncTimeoutPolicy GetDbTimeOutPolicy();
        AsyncCircuitBreakerPolicy GetDbCircuitBreakerPolicy();
        AsyncRetryPolicy GetDbRetryPolicy();
    }
}
