using System.Threading.Tasks;

namespace Ninjato.Common.Events 
{
  public interface IEventHandler<in T> where T : IEvent 
  {
    ///
    // This is an asynchronous method that handles the business logic for the input event (vent)
    ///
    Task HandleAsync (T vent);
  }
}