using System.Threading.Tasks;

namespace Ninjato.Common.Mongo
{
    /// <summary>
    /// Database seeder.
    /// </summary>
    public interface IDatabaseSeeder
    {
        /// <summary>
        /// Seeds the async.
        /// </summary>
        /// <returns>The async.</returns>
        Task SeedAsync();
    }
}