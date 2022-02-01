using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BusinessModel.Config;

namespace ConfigService.Consume
{
    public class AppConfigs: IAppConfigs
    {
        private readonly IAppConfiguration _siteConfigs;
        public AppConfigs(IAppConfiguration siteConfigs)
        {
            _siteConfigs = siteConfigs;
        }
        public string AppUiConfig()
        {
            return _siteConfigs.Environment;
        }
        public string GetAppEnv()
        {
            return _siteConfigs.Environment;
        }
    }
    public static class ExtntionM
    {
        public static void ApplicationConfiguration(this IServiceCollection services, IConfiguration appSettings)
        {
            services.AddSingleton<IAppConfiguration>(option=> new AppConfiguration
            {
                Environment = appSettings.GetSection("Environment").Value
            });
            services.AddSingleton<IAppConfigs, AppConfigs>();
        }
    }
}
