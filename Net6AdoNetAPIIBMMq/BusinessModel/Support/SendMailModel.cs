namespace BusinessModel.Support
{
    /// <summary>
    /// Defines the <see cref="SendMailModel" />.
    /// </summary>
    public class SendMailModel
    {
        /// <summary>
        /// Gets or sets the To.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets From
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or Sets isFilesAttached
        /// </summary>
        public string isFilesAttached { get; set; }
    }
}
