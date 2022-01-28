using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text;
using System.Text.Json;

namespace Net6AdoNetAPIIBMMq
{
    //https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-6.0
    public class HealthCheckPublisher : IHealthCheckPublisher
    {
        public Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
        {
            if (report.Status == HealthStatus.Healthy)
            {
                // ...
            }
            else
            {
                // ...
            }

            return Task.CompletedTask;
        }
    }
}
