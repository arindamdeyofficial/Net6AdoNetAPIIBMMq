
using System;

namespace BusinessModel.Config
{
    /// <summary>
    /// Defines the <see cref="ConfigModel" />.
    /// </summary>
    public class ConfigModel
    {
        /// <summary>
        /// MongoDb Id
        /// </summary>
        public string Id { get; set; }
        // <summary>
        /// Gets or sets the ApiUrl.
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the ApplicationId.
        /// </summary>
        public string ApplicationId { get; set; }
        /// <summary>
        /// Gets or sets the ApplicationName.
        /// </summary>
        public string ApplicationName { get; set; }
        /// <summary>
        /// Gets or sets the Environment.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Gets or sets the Tenant.
        /// </summary>
        public string Tenant { get; set; }

        /// <summary>
        /// Gets or sets the AllowedHosts.
        /// </summary>
        public string AllowedHosts { get; set; }

        /// <summary>
        /// Gets or sets the AppInsights Instrumentation Key
        /// </summary>
        public string InstrumentationKey { get; set; }

        /// <summary>
        /// Gets or sets TimeZones
        /// </summary>
        public string TimeZones { get; set; }        
    }
}
