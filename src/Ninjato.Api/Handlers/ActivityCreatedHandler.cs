using System;
using System.Threading.Tasks;
using Ninjato.Common.Events;

namespace Ninjato.Api.Handlers
{
    /// <summary>
    /// Activity created handler.
    /// </summary>
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated> 
    {
        /// <summary>
        /// Handles the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="vent">Vent.</param>
        public async Task HandleAsync (ActivityCreated vent) 
        {
            await Task.CompletedTask;

            Console.WriteLine ($"Activity Created: {vent.Name}");
        }
    }
}