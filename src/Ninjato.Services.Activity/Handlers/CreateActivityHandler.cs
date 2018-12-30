using System;
using System.Threading.Tasks;
using Ninjato.Common.Commands;
using Ninjato.Common.Events;
using RawRabbit;

namespace Ninjato.Services.Activity.Handlers
{
    /// <summary>
    /// Create activity handler.
    /// </summary>
    public class CreateActivityHandler : ICommandHandler<CreateActivity> 
    {

        private readonly IBusClient _busClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Services.Activity.Handlers.CreateActivityHandler"/> class.
        /// </summary>
        /// <param name="busClient">Bus client.</param>
        public CreateActivityHandler (IBusClient busClient) 
        {
            _busClient = busClient;
        }

        /// <summary>
        /// Handles the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="command">Command.</param>
        public async Task HandleAsync (CreateActivity command) 
        {
            Console.WriteLine($"Creating activity: {command.Name}");
            // producing an event
            await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, 
                command.Name, command.Description, command.CreatedAt));
        }
    }
}