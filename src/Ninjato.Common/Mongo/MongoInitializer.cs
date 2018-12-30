using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Ninjato.Common.Mongo
{
    /// <summary>
    /// Mongo initializer.
    /// </summary>
    public class MongoInitializer : IDatabaseInitializer 
    {
        private bool _initialized;

        private readonly bool _seed;

        private readonly IDatabaseSeeder _databaseSeeder;

        private readonly IMongoDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Mongo.MongoInitializer"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        /// <param name="databaseSeeder">Database seeder.</param>
        /// <param name="options">Options.</param>
        public MongoInitializer (IMongoDatabase database, IDatabaseSeeder databaseSeeder, IOptions<MongoOptions> options) 
        {
            _seed = options.Value.Seed;
            _databaseSeeder = databaseSeeder;
            _database = database;
        }

        /// <summary>
        /// Initializes the async.
        /// </summary>
        /// <returns>The async.</returns>
        public async Task InitializeAsync () 
        {
            if (_initialized) 
            {
                return;
            }

            RegisterConventions ();
            _initialized = true;

            if (!_seed) 
            {
                return;
            }
            await _databaseSeeder.SeedAsync(); // executes the seeder
        }

        /// <summary>
        /// Registers the conventions.
        /// </summary>
        private void RegisterConventions () 
        {
            ConventionRegistry.Register ("ActionConventions", new MongoConventions (), x => true);
        }

        /// <summary>
        /// Mongo conventions.
        /// </summary>
        private class MongoConventions : IConventionPack 
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention> {
                new IgnoreExtraElementsConvention (true), // if there are extra elements in the class thata are not serialized etc, don't throw exceptions
                new EnumRepresentationConvention (BsonType.String), // converts the enums to strings
                new CamelCaseElementNameConvention () // stpre all the keys as camelCase
            };
        }
    }
}