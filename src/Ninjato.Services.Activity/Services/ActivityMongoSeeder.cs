using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Ninjato.Common.Mongo;
using Ninjato.Services.Activity.Domain.Models;
using Ninjato.Services.Activity.Domain.Repositories;

namespace Ninjato.Services.Activity.Services
{
    public class ActivityMongoSeeder : MongoSeeder {
    private readonly ICategoryRepository _categoryRepository;

    public ActivityMongoSeeder (IMongoDatabase database,
      ICategoryRepository categoryRepository) : base (database) {
      _categoryRepository = categoryRepository;
    }

    protected override async Task CustomSeedAsync () {
      var categories = new List<string> {
        "work",
        "sport",
        "hobby"
      };
      
      await Task.WhenAll (categories.Select (category => _categoryRepository.AddAsync(new Category(category))));
    }
  }
}