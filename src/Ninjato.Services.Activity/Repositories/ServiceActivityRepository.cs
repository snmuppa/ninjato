using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Ninjato.Services.Activity.Domain.Models;
using Ninjato.Services.Activity.Domain.Repositories;

namespace Ninjato.Services.Activity.Repositories {
  public class ServiceActivityRepository : IServiceActivityRepository {

    private readonly IMongoDatabase _database;

    public ServiceActivityRepository (IMongoDatabase database) {
      _database = database;
    }

    public async Task<ServiceActivity> GetAsync (Guid id) => await Collection
      .AsQueryable ()
      .FirstOrDefaultAsync (activity => activity.Id == id);

    public async Task AddAsync (ServiceActivity serviceActivity) => await Collection.InsertOneAsync (serviceActivity);

    private IMongoCollection<ServiceActivity> Collection => _database.GetCollection<ServiceActivity> ("ServiceActivities");
  }
}