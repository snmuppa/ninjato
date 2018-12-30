using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Ninjato.Common.Mongo;
using Ninjato.Services.Activity.Domain.Models;
using Ninjato.Services.Activity.Domain.Repositories;

namespace Ninjato.Services.Activity.Services
{
    /// <summary>
    /// Activity mongo seeder.
    /// </summary>
    public class ActivityMongoSeeder : MongoSeeder 
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Activity.Services.ActivityMongoSeeder"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        /// <param name="categoryRepository">Category repository.</param>
        public ActivityMongoSeeder (IMongoDatabase database,
            ICategoryRepository categoryRepository) : base (database) 
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Customs the seed async.
        /// </summary>
        /// <returns>The seed async.</returns>
        protected override async Task CustomSeedAsync () 
        {
            var categories = new List<string> 
            {
                "work",
                "sport",
                "hobby"
            };

            await Task.WhenAll (categories.Select (category => _categoryRepository.AddAsync(new Category(category))));
        }
    }
}