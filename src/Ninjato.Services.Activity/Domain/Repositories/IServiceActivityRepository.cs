using System;
using System.Threading.Tasks;
using Ninjato.Services.Activity.Domain.Models;

namespace Ninjato.Services.Activity.Domain.Repositories
{
    /// <summary>
    /// Service activity repository.
    /// </summary>
    public interface IServiceActivityRepository 
    {
        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="id">Identifier.</param>
        Task<ServiceActivity> GetAsync (Guid id);

        /// <summary>
        /// Adds the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="activity">Activity.</param>
        Task AddAsync (ServiceActivity activity);
    }
}