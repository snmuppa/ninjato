using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Ninjato.Common.Mongo
{
    /// <summary>
    /// Mongo seeder.
    /// </summary>
    public class MongoSeeder : IDatabaseSeeder 
    {
        protected readonly IMongoDatabase Database;

        public MongoSeeder (IMongoDatabase database) 
        {
            Database = database;
        }

        /// <summary>
        /// Seeds the async.
        /// </summary>
        /// <returns>The async.</returns>
        public async Task SeedAsync () 
        {
            var collectionCursor = await Database.ListCollectionsAsync();
            var collections = await collectionCursor.ToListAsync();
            if(collections.Any())
            {
                return;
            }
            await CustomSeedAsync();
        }

        /// <summary>
        /// Customs the seed async.
        /// </summary>
        /// <returns>The seed async.</returns>
        protected virtual async Task CustomSeedAsync() 
        {
            await Task.CompletedTask; // this does nothing
        }
    }
}