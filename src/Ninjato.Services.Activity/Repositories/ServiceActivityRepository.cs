using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Ninjato.Services.Activity.Domain.Models;
using Ninjato.Services.Activity.Domain.Repositories;

namespace Ninjato.Services.Activity.Repositories
{
    /// <summary>
    /// Service activity repository.
    /// </summary>
    public class ServiceActivityRepository : IServiceActivityRepository 
    {

        private readonly IMongoDatabase _database;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Ninjato.Services.Activity.Repositories.ServiceActivityRepository"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        public ServiceActivityRepository (IMongoDatabase database) 
        {
            _database = database;
        }

        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<ServiceActivity> GetAsync (Guid id) => await Collection
            .AsQueryable ()
            .FirstOrDefaultAsync (activity => activity.Id == id);

        /// <summary>
        /// Adds the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="serviceActivity">Service activity.</param>
        public async Task AddAsync (ServiceActivity serviceActivity) => await Collection.InsertOneAsync (serviceActivity);

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>The collection.</value>
        private IMongoCollection<ServiceActivity> Collection => _database.GetCollection<ServiceActivity> ("ServiceActivities");
    }
}