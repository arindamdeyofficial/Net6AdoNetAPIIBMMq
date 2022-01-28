using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text;
using System.Text.Json;

namespace Net6AdoNetAPIIBMMq
{
    //https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0
    public class HealthCheckWithArgs : IHealthCheck
    {
        private readonly int _arg1;
        private readonly string _arg2;

        public HealthCheckWithArgs(int arg1, string arg2)
            => (_arg1, _arg2) = (arg1, arg2);

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            // ...

            return Task.FromResult(HealthCheckResult.Healthy("A healthy result."));
        }
    }
}
