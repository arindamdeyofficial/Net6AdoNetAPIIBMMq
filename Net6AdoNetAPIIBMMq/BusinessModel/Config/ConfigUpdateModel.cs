using BusinessModel.Config;

namespace BusinessModel.Config
{
    /// <summary>
    /// Defines the <see cref="ConfigUpdateModel" />.
    /// </summary>
    public class ConfigUpdateModel
    {
        // <summary>
        /// Gets or sets the ApiUrl.
        /// </summary>
        public ConfigModel OldConfig { get; set; }

        /// <summary>
        /// Gets or sets the ApplicationId.
        /// </summary>
        public ConfigModel NewConfig { get; set; }
    }
}
