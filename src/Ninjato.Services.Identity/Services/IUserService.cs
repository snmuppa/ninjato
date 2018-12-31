using System.Threading.Tasks;
using Ninjato.Common.Authentication;

namespace Ninjato.Services.Identity.Services
{
    /// <summary>
    /// User service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers the user asynchronously.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        /// <param name="name">Name.</param>
        Task RegisterAsync(string email, string password, string name);

        /// <summary>
        /// Logins the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="email">Email.</param>
        /// <param name="password">Password.</param>
        Task<JsonWebToken> LoginAsync(string email, string password);
    }
}
