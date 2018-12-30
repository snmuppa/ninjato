using System.Collections.Generic;
using System.Threading.Tasks;
using Ninjato.Services.Activity.Domain.Models;

namespace Ninjato.Services.Activity.Domain.Repositories
{
    /// <summary>
    /// Category repository.
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Fetches the category for a given name
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="name">Name.</param>
        Task<Category> GetAsync(string name);

        /// <summary>
        /// Fetches all the categories that are available
        /// </summary>
        /// <returns>The async.</returns>
        Task<IEnumerable<Category>> BrowseAsync();

        /// <summary>
        /// Adds a category
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="category">Category.</param>
        Task AddAsync(Category category);
    }
}