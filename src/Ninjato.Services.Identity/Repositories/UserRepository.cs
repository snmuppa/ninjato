using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Ninjato.Services.Identity.Domain.Models;
using Ninjato.Services.Identity.Domain.Repositories;

namespace Ninjato.Services.Identity.Repositories
{
    /// <summary>
    /// User repository.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Identity.Repositories.UserRepository"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="user">User.</param>
        public async Task AddAsync(User user) 
            => await Collection.InsertOneAsync(user);

        /// <summary>
        /// Gets the user by id.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="id">Identifier.</param>
        public async Task<User> GetAsync(Guid id) 
            => await Collection
               .AsQueryable()
               .FirstOrDefaultAsync(user => user!= null && user.Id == id);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="email">Email.</param>
        public async Task<User> GetAsync(string email)
            => await Collection
               .AsQueryable()
               .FirstOrDefaultAsync(user => user != null && user.Email == email);

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <value>The collection.</value>
        private IMongoCollection<User> Collection
            => _database.GetCollection<User>("Users");
    }
}
