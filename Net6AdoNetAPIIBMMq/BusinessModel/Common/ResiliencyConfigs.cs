using System.Diagnostics.CodeAnalysis;

namespace BusinessModel.Common
{
    [ExcludeFromCodeCoverage]
    public class ResiliencyConfigs
    {
        /// <summary>
        /// Gets or sets the .
        /// </summary>
        public int ResiliencyEnabled { get; set; }

        /// <summary>
        /// Gets or sets the .
        /// </summary>
        public int FallBackEnabled { get; set; }

        /// <summary>
        /// Gets or sets the .
        /// </summary>
        public int RetryEnabled { get; set; }

        /// <summary>
        /// Gets or sets the .
        /// </summary>
        public int CircuitBreakerEnabled { get; set; }

        /// <summary>
        /// Gets or sets the .
        /// </summary>
        public int BulkHeadEnabled { get; set; }

        /// <summary>
        /// Gets or sets the .
        /// </summary>
        public int TimeOutEnabled { get; set; }

    }
}
