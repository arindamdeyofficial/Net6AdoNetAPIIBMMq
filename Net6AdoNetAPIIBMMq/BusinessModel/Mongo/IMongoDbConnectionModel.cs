namespace BusinessModel.Mongo
{
    /// <summary>
    /// Defines the <see cref="IMongoDbConnectionModel" />.
    /// </summary>
    public interface IMongoDbConnectionModel
    {
        // <summary>
        /// Gets or sets the ConnectionString
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the DbName.
        /// </summary>
        public string DbName { get; set; }
        /// <summary>
        /// Gets or sets the CollectionName
        /// </summary>
        public string CollectionName { get; set; }
    }
}
