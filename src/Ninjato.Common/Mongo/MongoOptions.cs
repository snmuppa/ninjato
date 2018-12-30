namespace Ninjato.Common.Mongo
{
    /// <summary>
    /// Mongo options.
    /// </summary>
    public class MongoOptions
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the Database name.
        /// </summary>
        /// <value>The database.</value>
        public string Database { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Ninjato.Common.Mongo.MongoOptions"/> is seed.
        /// </summary>
        /// <value><c>true</c> if seed; otherwise, <c>false</c>.</value>
        public bool Seed { get; set; }
    }
}