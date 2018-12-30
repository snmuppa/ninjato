using System.Threading.Tasks;

namespace Ninjato.Common.Mongo
{
    /// <summary>
    /// Database initializer.
    /// </summary>
    public interface IDatabaseInitializer
    {
        /// <summary>
        /// Initializes the async.
        /// </summary>
        /// <returns>The async.</returns>
        Task InitializeAsync();
    }
}