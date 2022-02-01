using BusinessModel.Mongo;

namespace BusinessModel.Mongo
{
    /// <summary>
    /// Defines the <see cref="MongoDbConnectionModel" />.
    /// </summary>
    public class MongoDbConnectionModel: IMongoDbConnectionModel
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
