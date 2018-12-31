using System;
using System.Threading.Tasks;
using Ninjato.Common.Exceptions;
using Ninjato.Services.Activity.Domain.Models;
using Ninjato.Services.Activity.Domain.Repositories;

namespace Ninjato.Services.Activity.Services
{
    /// <summary>
    /// Activity service.
    /// </summary>
    public class ActivityService : IActivityService
    {
        private readonly IServiceActivityRepository _serviceActivityRepository;

        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Activity.Services.ActivityService"/> class.
        /// </summary>
        /// <param name="serviceActivityRepository">Service activity repository.</param>
        /// <param name="categoryRepository">Category repository.</param>
        public ActivityService(IServiceActivityRepository serviceActivityRepository, ICategoryRepository categoryRepository)
        {
            _serviceActivityRepository = serviceActivityRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Adds the activity to the activity respository.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="id">Identifier.</param>
        /// <param name="userId">User identifier.</param>
        /// <param name="category">Category.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <param name="createdAt">Created at.</param>
        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(name);
            if(activityCategory == null)
            {
                throw new NinjatoException("category_not_found", $"Category: '{category}' was not found.");
            }

            var serviceActivity = new ServiceActivity(id, activityCategory, userId, name, description, createdAt);

            await _serviceActivityRepository.AddAsync(serviceActivity);
        }
    }
}
