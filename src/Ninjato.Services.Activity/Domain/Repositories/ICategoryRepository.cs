using System.Collections.Generic;
using System.Threading.Tasks;
using Ninjato.Services.Activity.Domain.Models;

namespace Ninjato.Services.Activity.Domain.Repositories
{
  public interface ICategoryRepository
  {
    ///
    // Fetches the category for a given name
    ///
    Task<Category> GetAsync(string name);

    ///
    // fetches all the categories that are available
    ///
    Task<IEnumerable<Category>> BrowseAsync();
    
    ///
    // Adds a category
    ///
    Task AddAsyncCategory(Category category);
  }
}