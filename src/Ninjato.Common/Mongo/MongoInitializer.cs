using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Ninjato.Common.Mongo {
  public class MongoInitializer : IDatabaseInitializer {
    private bool _initialized;

    private readonly bool _seed;

    private readonly IMongoDatabase _database;

    public MongoInitializer(IMongoDatabase database, IOptions<MongoOptions> options)
    {
      _seed = options.Value.Seed;
      _database = database;
    }

    public async Task InitializeAsync() 
    {
      if(_initialized)
      {
        return;
      }

      RegisterConventions();
      _initialized = true;

      if(!_seed)
      {
        return;
      }
    }

    private void RegisterConventions()
    {
      ConventionRegistry.Register("ActionConventions", new MongoConventions(), x => true);
    }

    private class MongoConventions : IConventionPack
    {
      public IEnumerable<IConvention> Conventions => new List<IConvention>
      {
        new IgnoreExtraElementsConvention(true), // if there are extra elements in the class thata are not serialized etc, don't throw exceptions
        new EnumRepresentationConvention(BsonType.String), // converts the enums to strings
        new CamelCaseElementNameConvention() // stpre all the keys as camelCase
      };
    }
  }
}