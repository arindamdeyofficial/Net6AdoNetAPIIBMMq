using BusinessModel.Common;
using BusinessModel.Config;
using ConfigService.Consume;
using HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resiliency;
using System.Diagnostics.CodeAnalysis;

namespace Net6AdoNetAPIIBMMq
{
    /// <summary>
    /// PollyConfigure for resiliency
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class PollyConfigure
    {
        /// <summary>
        /// Configures Polly for resiliency
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="apiaddrs"></param>
        /// <param name="logicAppendpt"></param>
        public static void Configure(IServiceCollection services, IConfiguration configuration
            , IApiBaseAddress apiaddrs)
        {
            var prov = services.BuildServiceProvider();
            var apiRequestHandlerProvider = prov.GetService<IApiRequestHandler>();
            var polyHttpPolicyHandlerProvider = prov.GetService<IPloyHttpPolicyHandler>();

            services.AddSingleton<IPolyDbPolicyHandler>(new PloyPolicyHandler(apiRequestHandlerProvider, configuration));

            services.AddHttpClient("HttpClient")
               .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
               .AddPolicyHandler(polyHttpPolicyHandlerProvider.GetRetryPolicy()) //Retry
               .AddPolicyHandler(polyHttpPolicyHandlerProvider.GetCircuitBreakerPolicy()) //Circuit Breaker
               //.AddPolicyHandler(polyHttpPolicyHandlerProvider.GetHttpFallbackPolicy()) //FallBack
               ;

            services.AddHttpClient<ICustomConfigService, CustomConfigService>(client =>
            {
                client.BaseAddress = new Uri(apiaddrs.ConfigServiceUrl);
            })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
               .AddPolicyHandler(polyHttpPolicyHandlerProvider.GetRetryPolicy()) //Retry
               .AddPolicyHandler(polyHttpPolicyHandlerProvider.GetCircuitBreakerPolicy()); //Circuit Breaker
                        
            services.AddHttpClient<IConfigClient, ConfigClient>(client =>
            {
                client.BaseAddress = new Uri(apiaddrs.ConfigServiceUrl);
            })
               .SetHandlerLifetime(TimeSpan.FromMinutes(5))  //Set lifetime to five minutes
              .AddPolicyHandler(polyHttpPolicyHandlerProvider.GetRetryPolicy()) //Retry
              .AddPolicyHandler(polyHttpPolicyHandlerProvider.GetCircuitBreakerPolicy()); //Circuit Breaker
        }
    }
}
