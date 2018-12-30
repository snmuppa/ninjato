using System.Threading.Tasks;

namespace Ninjato.Common.Mongo
{
  public interface IDatabaseInitializer
  {
    Task InitilizeAsync();
  }
}