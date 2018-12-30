using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Ninjato.Services.Activity.Domain.Models;
using Ninjato.Services.Activity.Domain.Repositories;

namespace Ninjato.Services.Activity.Repositories
{
    /// <summary>
    /// Category repository.
    /// </summary>
    public class CategoryRepository : ICategoryRepository 
    {
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Activity.Repositories.CategoryRepository"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        public CategoryRepository (IMongoDatabase database) 
        {
            _database = database;
        }

        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="name">Name.</param>
        public async Task<Category> GetAsync (string name)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(category => category != null && category.Name == name.ToLowerInvariant());

        /// <summary>
        /// Adds the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="category">Category.</param>
        public async Task AddAsync (Category category)
            => await Collection.InsertOneAsync(category);

        /// <summary>
        /// Browses the async.
        /// </summary>
        /// <returns>The async.</returns>
        public async Task<IEnumerable<Category>> BrowseAsync () 
            => await Collection
                .AsQueryable()
                .ToListAsync();

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>The collection.</value>
        private IMongoCollection<Category> Collection => _database.GetCollection<Category> ("Categories");
    }
}