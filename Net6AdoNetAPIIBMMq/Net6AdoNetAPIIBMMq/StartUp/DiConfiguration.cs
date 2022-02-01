using BusinessModel.Common;
using ExceptionHandler;
using Resiliency;
using System.Diagnostics.CodeAnalysis;

namespace Net6AdoNetAPIIBMMq
{
    /// <summary>
    /// DiConfiguration
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DiConfiguration
    {
        /// <summary>
        /// Configures DI in application
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {      
            services.AddScoped<IApiRequestHandler, HandleExceptionPrivateAttribute>();
            //services.AddTransient<IUserContext, UserContext>();
            //services.AddTransient<IRoleService, RoleService>();
            //services.AddTransient<ITokenService, TokenService>();
            //services.AddTransient<ITokenNotificationService, TokenNotificationService>();
            services.AddScoped<IPloyHttpPolicyHandler, PloyPolicyHandler>();
            //services.AddScoped<IEmailClient, EmailClient>();
            //services.AddTransient<IUserConnectionManager, UserConnectionManager>();
        }
    }
}
