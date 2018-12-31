using System;
using System.Threading.Tasks;

namespace Ninjato.Services.Activity.Services
{
    /// <summary>
    /// Activity service.
    /// </summary>
    public interface IActivityService
    {
        /// <summary>
        /// Adds an activity from the command.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="guid">GUID.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="category">Category.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="createdAt">Created at.</param>
        Task AddAsync(Guid guid, Guid userId, string category, string name, string description, DateTime createdAt);
    }
}
