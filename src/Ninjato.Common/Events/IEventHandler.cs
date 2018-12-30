using System.Threading.Tasks;

namespace Ninjato.Common.Events 
{
    /// <summary>
    /// Event handler.
    /// </summary>
    public interface IEventHandler<in T> where T : IEvent 
    {
        /// <summary>
        /// This is an asynchronous method that handles the business logic for the input event (vent)
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="vent">Vent.</param>
        Task HandleAsync (T vent);
    }
}