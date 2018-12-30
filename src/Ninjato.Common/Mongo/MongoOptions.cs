namespace Ninjato.Common.Mongo
{
  public class MongoOptions
  {
    public string ConnectionString { get; set; }

    // Used to hold the connection Database name
    public string Database { get; set; }

    // used for seeding (seed with the required data if needed) the MongoDB 
    public bool Seed { get; set; }
  }
}