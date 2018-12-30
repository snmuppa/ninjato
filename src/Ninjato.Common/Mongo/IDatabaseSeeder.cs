using System.Threading.Tasks;

namespace Ninjato.Common.Mongo
{
  public interface IDatabaseSeeder
  {
    Task SeedAsync();
  }
}